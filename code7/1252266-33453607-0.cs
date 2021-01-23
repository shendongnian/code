    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ConsoleApplication1.ServiceReference1;
    using System.Net;
    using System.Xml.Serialization;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Soap;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
        [Serializable]
        public class Foo
        {
            public Foo() { }
            public Foo(int id, string name)
            {
                Id = id;
                Name=name;
            }
            public int Id { get; set; }
            public string Name { get; set; }
        }
    
        [Serializable]
        public class Roman
        {
            public Roman() { }
            public Roman(int id, string bushuev, string somethingElse)
            {
                Id = id;
                Bushuev = bushuev;
                SomethingElse = somethingElse;
            }
            public int Id { get; set; }
            public string Bushuev { get; set; }
            public string SomethingElse { get; set; }
        }
    
        class Program
        {
            public static Stream GenerateStreamFromString(string s)
            {
                MemoryStream stream = new MemoryStream();
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(s);
                writer.Flush();
                stream.Position = 0;
                return stream;
            }
            public static string GeneralSerilize<T>(T input)
            {
                string result=null;
                XmlSerializer xmlSerializer =
                    new XmlSerializer(input.GetType());
                using (StringWriter textWriter = new StringWriter())
                {
                    xmlSerializer.Serialize(textWriter, input);
                    result = textWriter.ToString();
                    string pattern = string.Format("(?<first><{0}(.|\r|\n)+{0}>)",input.GetType().Name);
                    Match match = Regex.Match(result, pattern);
                    result = match.Value;
                    result = result.Replace(
                        @"xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""",
                        string.Empty);
    
                    result = result.Replace(input.GetType().Name,
                                        input.GetType().Name.ToLower());
                }
                return result;
            }
            public static T GeneralDeserialize<T>(string input) where T:class
            {
                T result = null;
                XmlSerializer xml = new XmlSerializer(typeof(T));
    
                {
                    string inptuResult = input;
                    string pattern = string.Format("(?<first><{0}(.|\r|\n)+{0}>)", typeof(T).Name);
                    Match match = Regex.Match(input, pattern);
                    input = match.Value;
                }
    
                using (Stream stream = GenerateStreamFromString(input))
                {
                    result = (T)xml.Deserialize(stream);
                }
    
                return result;
            }
    
            public static T UseWEbService<T>(T input, string nameMethod) where T:class
            {
                string xmlResult = GeneralSerilize<T>(input);
    
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        string stringAction = string.Format("\"http://tempuri.org/{0}\"",nameMethod);
                        client.Headers.Add("SOAPAction", stringAction);
    
                        client.Headers.Add("Content-Type", "text/xml; charset=utf-8");
                        string payload= string.Empty;
                        string begin = @"<?xml version=""1.0"" encoding=""utf-8""?>
                                        <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" 
                                                        xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
                                                        xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                                          <soap:Body>";
                        
                        string end =@"</soap:Body>
                                        </soap:Envelope>";
    
                        string beginMethod = string.Empty;
                        beginMethod = string.Format(@"<{0} xmlns=""http://tempuri.org/"">",nameMethod);//"<" + nameMethod + ">";
    
                        string endMethod = string.Empty;
                        endMethod = "</" + nameMethod + ">";
                        payload = begin + 
                             beginMethod+
                             xmlResult+
                             endMethod
                             + end;
    
                        byte[] data = Encoding.UTF8.GetBytes(payload);
                        byte[] webServiceResponse = client.UploadData("http://localhost:22123/Service1.asmx", data);
                        string stringResponse = Encoding.Default.GetString(webServiceResponse);
                        
                        try
                        {
                            string inputXML = stringResponse.Replace(nameMethod + "Result", input.GetType().Name);
                            T resultMethod = GeneralDeserialize<T>(inputXML);
                            return resultMethod;
                        }
    
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
    
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                return null;
            }
            static void Main(string[] args)
            {
                Foo foo = UseWEbService < Foo>(new Foo(10, "roman"), "HelloWorld");
                Roman roman = new Roman(123,
                    "roman ", "bushuev");
                Roman romanResult = UseWEbService<Roman>(roman, "HelloRoman");          
            }
        }
    }
