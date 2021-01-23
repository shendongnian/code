    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Resources;
    
    namespace HQ.Util.General
    {
        public static class ResourceHelper
        {
            // ******************************************************************
            /// <summary>
            /// The resource should be defined as 'Resource' not as 'Embedded resource'.
            /// </summary>
            /// <param name="resourcePath">The resource path</param>
            /// <param name="assembly">If null, then use calling assembly to find the resource</param>
            /// <returns></returns>
            public static Uri GetLocationUri(string resourcePath, Assembly assembly = null)
            {
                if (assembly == null)
                {
                    assembly = Assembly.GetCallingAssembly();
                }
    
                resourcePath = resourcePath.Replace('\\', '/');
    
                return new Uri(@"pack://application:,,,/" + assembly.GetName().Name + ";component" +
                    (resourcePath[0] == '/' ? resourcePath : "/" + resourcePath), UriKind.Absolute);
            }
    
            // ******************************************************************
            /// <summary>
            /// Will load resource from any assembly that is part of the application.
            /// It does not rely on Application which is specific to a (UI) frameowrk.
            /// </summary>
            /// <param name="uri"></param>
            /// <param name="asm"></param>
            /// <returns></returns>
            public static Stream LoadResourceFromUri(Uri uri, Assembly asm = null)
            {
                Stream stream = null;
    
                if (uri.Authority.StartsWith("application") && uri.Scheme == "pack")
                {
                    string localPath = uri.GetComponents(UriComponents.Path, UriFormat.UriEscaped);
    
                    int indexLocalPathWithoutAssembly = localPath.IndexOf(";component/");
                    if (indexLocalPathWithoutAssembly == -1)
                    {
                        indexLocalPathWithoutAssembly = 0;
                    }
                    else
                    {
                        indexLocalPathWithoutAssembly += 11;
                    }
    
                    if (asm != null) // Take the provided assembly, do not check for the asm in the uri.
                    {
                        stream = GetAssemblyResourceStream(asm, localPath.Substring(indexLocalPathWithoutAssembly));
                    }
                    else
                    {
                        if (uri.Segments.Length > 1)
                        {
                            if (uri.Segments[0] == "/" && uri.Segments[1].EndsWith(";component/"))
                            {
                                int index = uri.Segments[1].IndexOf(";");
                                if (index > 0)
                                {
                                    string assemblyName = uri.Segments[1].Substring(0, index);
    
                                    foreach (Assembly asmIter in AppDomain.CurrentDomain.GetAssemblies())
                                    {
                                        if (asmIter.GetName().Name == assemblyName)
                                        {
                                            stream = GetAssemblyResourceStream(asmIter, localPath.Substring(indexLocalPathWithoutAssembly));
                                            break;
                                        }
                                    }
                                }
                            }
                        }
    
                        if (stream == null)
                        {
                            asm = Assembly.GetCallingAssembly();
                            stream = GetAssemblyResourceStream(asm, localPath.Substring(indexLocalPathWithoutAssembly));
                        }
                    }
                }
                return stream;
            }
    
            // ******************************************************************
            /// <summary>
            /// The path separator is '/'.  The path should not start with '/'.
            /// </summary>
            /// <param name="asm"></param>
            /// <param name="path"></param>
            /// <returns></returns>
            public static Stream GetAssemblyResourceStream(Assembly asm, string path)
            {
                // Just to be sure
                if (path[0] == '/')
                {
                    path = path.Substring(1);
                }
    
                // Just to be sure
                if (path.IndexOf('\\') == -1)
                {
                    path = path.Replace('\\', '/');
                }
    
                Stream resStream = null;
    
                string resName = asm.GetName().Name + ".g.resources"; // Ref: Thomas Levesque Answer at:
                // http://stackoverflow.com/questions/2517407/enumerating-net-assembly-resources-at-runtime
    
                using (var stream = asm.GetManifestResourceStream(resName))
                {
                    using (var resReader = new System.Resources.ResourceReader(stream))
                    {
                        string dataType = null;
                        byte[] data = null;
                        try
                        {
                            resReader.GetResourceData(path.ToLower(), out dataType, out data);
                        }
                        catch (Exception ex)
                        {
                            DebugPrintResources(resReader);
                        }
    
                        if (data != null)
                        {
                            switch (dataType) // COde from 
                            {
                                // Handle internally serialized string data (ResourceTypeCode members).
                                case "ResourceTypeCode.String":
                                    BinaryReader reader = new BinaryReader(new MemoryStream(data));
                                    string binData = reader.ReadString();
                                    Console.WriteLine("   Recreated Value: {0}", binData);
                                    break;
                                case "ResourceTypeCode.Int32":
                                    Console.WriteLine("   Recreated Value: {0}", BitConverter.ToInt32(data, 0));
                                    break;
                                case "ResourceTypeCode.Boolean":
                                    Console.WriteLine("   Recreated Value: {0}", BitConverter.ToBoolean(data, 0));
                                    break;
                                // .jpeg image stored as a stream.
                                case "ResourceTypeCode.Stream":
                                    ////const int OFFSET = 4;
                                    ////int size = BitConverter.ToInt32(data, 0);
                                    ////Bitmap value1 = new Bitmap(new MemoryStream(data, OFFSET, size));
                                    ////Console.WriteLine("   Recreated Value: {0}", value1);
    
                                    const int OFFSET = 4;
                                    resStream = new MemoryStream(data, OFFSET, data.Length - OFFSET);
    
                                    break;
                                // Our only other type is DateTimeTZI.
                                default:
                                    ////// No point in deserializing data if the type is unavailable.
                                    ////if (dataType.Contains("DateTimeTZI") && loaded)
                                    ////{
                                    ////    BinaryFormatter binFmt = new BinaryFormatter();
                                    ////    object value2 = binFmt.Deserialize(new MemoryStream(data));
                                    ////    Console.WriteLine("   Recreated Value: {0}", value2);
                                    ////}
                                    ////break;
                                    break;
                            }
                            
                            // resStream = new MemoryStream(resData);
                        }
                    }
                }
    
                return resStream;
            }
    
            // ******************************************************************
            private static void DebugPrintResources(System.Resources.ResourceReader reader)
            {
                Debug.Print("Begin dump resources: ---------------------");
                foreach (DictionaryEntry item in reader)
                {
                    Debug.Print(item.Key.ToString());
                }
                Debug.Print("End   dump resources: ---------------------");
            }
    
            // ******************************************************************        // ******************************************************************
        }
    }
