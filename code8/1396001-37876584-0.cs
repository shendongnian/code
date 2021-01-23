    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.Xml.Linq;
    namespace UnitTestProject1
    {
        public class ServiceDetail
        {
            public Uri WSDLUri { get; set; }
            public Uri ServiceUri { get; set; }
            public String ContractName { get; set; }
            public string MethodName { get; set; }
        }
        public class GenericService
        {
            public object Call(ServiceDetail svc, List<object> payLoads)
            {
                //Import WSDL
                WsdlImporter imptr = ImportWSDL(svc.WSDLUri);
                //Extract Service and Data Contract Descriptions
                Collection<ContractDescription> svcCtrDesc = imptr.ImportAllContracts();
                //Compile the description to assembly
                var assembly = GetAssembly(svcCtrDesc);
                if (assembly == null) return null;
                //Extract all end points available on the WSDL
                IDictionary<string, IEnumerable<ServiceEndpoint>> allEP = GetEndPointsOfEachServiceContract(imptr, svcCtrDesc);
                IEnumerable<ServiceEndpoint> currentSvcEP;
                if (allEP.TryGetValue(svc.ContractName, out currentSvcEP))
                {
                    //Find the endpoint of the service to which the proxy needs to contact
                    var svcEP = currentSvcEP.First(x => x.ListenUri.AbsoluteUri == svc.ServiceUri.AbsoluteUri);
                    //Generate proxy
                    var proxy = GetProxy(svc.ContractName, svcEP, assembly);
                    //Deserialize each payload argument to object
                    List<object> pls = new List<object>();
                    foreach (var pl in payLoads)
                    {
                        object clrObj = null;
                        try
                        {
                            clrObj = Deserialize(pl.ToString(), assembly);
                        }
                        catch
                        {
                            clrObj = pl;
                        }
                        pls.Add(clrObj);
                    }
                    //Find opration contract on the proxy and invoke
                    return proxy.GetType().GetMethod(svc.MethodName).Invoke(proxy, pls.ToArray());
                }
                return null;
            }
            private Assembly GetAssembly(Collection<ContractDescription> svcCtrDesc)
            {
                CodeCompileUnit ccu = GetServiceAndDataContractCompileUnitFromWSDL(svcCtrDesc);
                CompilerResults rslt = GenerateContractsAssemblyInMemory(new CodeCompileUnit[] { ccu });
                if (!rslt.Errors.HasErrors)
                    return rslt.CompiledAssembly;
                return null;
            }
            private object GetProxy(string ctrName, ServiceEndpoint svcEP, Assembly assembly)
            {
                Type prxyT = assembly.GetTypes().First(t => t.IsClass && t.GetInterface(ctrName) != null && t.GetInterface(typeof(ICommunicationObject).Name) != null);
                object proxy = assembly.CreateInstance(prxyT.Name, false, System.Reflection.BindingFlags.CreateInstance,
                                        null, new object[] { svcEP.Binding, svcEP.Address }, CultureInfo.CurrentCulture, null);
                return proxy;
            }
            private WsdlImporter ImportWSDL(Uri wsdlLoc)
            {
                MetadataExchangeClient mexC = new MetadataExchangeClient(wsdlLoc, MetadataExchangeClientMode.HttpGet);
                mexC.ResolveMetadataReferences = true;
                MetadataSet metaSet = mexC.GetMetadata();
                return new WsdlImporter(metaSet);
            }
            private Dictionary<string, IEnumerable<ServiceEndpoint>> GetEndPointsOfEachServiceContract(WsdlImporter imptr, Collection<ContractDescription> svcCtrDescs)
            {
                ServiceEndpointCollection allEP = imptr.ImportAllEndpoints();
                var ctrEP = new Dictionary<string, IEnumerable<ServiceEndpoint>>();
                foreach (ContractDescription svcCtrDesc in svcCtrDescs)
                {
                    List<ServiceEndpoint> eps = allEP.Where(x => x.Contract.Name == svcCtrDesc.Name).ToList();
                    ctrEP.Add(svcCtrDesc.Name, eps);
                }
                return ctrEP;
            }
            private CodeCompileUnit GetServiceAndDataContractCompileUnitFromWSDL(Collection<ContractDescription> svcCtrDescs)
            {
                ServiceContractGenerator svcCtrGen = new ServiceContractGenerator();
                foreach (ContractDescription ctrDesc in svcCtrDescs)
                {
                    svcCtrGen.GenerateServiceContractType(ctrDesc);
                }
                return svcCtrGen.TargetCompileUnit;
            }
            private object Deserialize(string xml, Assembly assembly)
            {
                Type ctr = GetDataContractType(xml, assembly);
                return Deserialize(xml, ctr);
            }
            private object Deserialize(string xml, Type toType)
            {
                using (Stream stream = new MemoryStream())
                {
                    byte[] data = System.Text.Encoding.UTF8.GetBytes(xml);
                    stream.Write(data, 0, data.Length);
                    stream.Position = 0;
                    DataContractSerializer d = new DataContractSerializer(toType);
                    return d.ReadObject(stream);
                }
            }
            private Type GetDataContractType(string xml, Assembly assembly)
            {
                var serializedXML = ConvertToXML(xml);
                var match = assembly.GetTypes().First(x => x.Name == serializedXML.Root.Name.LocalName);
                return match;
            }
            private XDocument ConvertToXML(string xml)
            {
                using (Stream stream = new MemoryStream())
                {
                    byte[] data = System.Text.Encoding.UTF8.GetBytes(xml);
                    stream.Write(data, 0, data.Length);
                    stream.Position = 0;
                    return XDocument.Load(stream);
                }
            }
            private CompilerResults GenerateContractsAssemblyInMemory(params CodeCompileUnit[] codeCompileUnits)
            {
                // Generate a code file for the contracts 
                CodeGeneratorOptions opts = new CodeGeneratorOptions();
                opts.BracingStyle = "C";
                CodeDomProvider pro = CodeDomProvider.CreateProvider("C#");
                // Compile the code file to an in-memory assembly
                // Don't forget to add all WCF-related assemblies as references
                CompilerParameters prms = new CompilerParameters(new string[] { "System.dll", "System.ServiceModel.dll",
                    "System.Runtime.Serialization.dll"});
                prms.GenerateInMemory = true;
                prms.GenerateExecutable = false;
                return pro.CompileAssemblyFromDom(prms, codeCompileUnits);
            }
        }
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {
                // Arrange         
                var target = new GenericService();
                var serviceDetail = new ServiceDetail
                {
                    WSDLUri = new Uri("http://localhost:13152/Service1.svc?singleWsdl"),
                    ServiceUri = new Uri("http://localhost:13152/Service1.svc"),
                    ContractName = "IService1",
                    MethodName = "GetData"
                };
                var arguments = new List<object> { 5 };
                // Act
                var result = target.Call(serviceDetail, arguments);
                // Assert
                Assert.AreEqual("You entered: 5", result);
            }
        }
    }
