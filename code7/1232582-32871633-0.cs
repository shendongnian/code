    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Windows;
    using System.Windows.Media.Imaging;
    using System.Windows.Resources;
    using MoreLinq;
    
    namespace UriInternal
    {
        public class ResourceHelper
        {
            // ******************************************************************
            /// <summary>
            /// Load a resource WPF-BitmapImage (png, bmp, ...) from embedded resource defined as 'Resource' not as 'Embedded resource'.
            /// </summary>
            /// <param name="pathInApplication">Path without starting slash</param>
            /// <param name="assembly">Usually 'Assembly.GetExecutingAssembly()'. If not mentionned, I will use the calling assembly</param>
            /// <returns></returns>
            public static BitmapImage LoadBitmapFromResource(string pathInApplication, Assembly assembly = null)
            {
                if (assembly == null)
                {
                    assembly = Assembly.GetCallingAssembly();
                }
    
                return new BitmapImage(GetLocationUri(pathInApplication, assembly));
            }
    
            // ******************************************************************
            /// <summary>
            /// The resource should be defined as 'Resource' not as 'Embedded resource'.
            /// Example: 			
            ///		StreamResourceInfo info = ResourceHelper.GetResourceStreamInfo(@"Resources/GraphicUserGuide.html");
            ///		if (info != null)
            ///		{
            ///			WebBrowser.NavigateToStream(info.Stream);
            ///		}
            /// </summary>
            /// <param name="path">The path start with folder name (if any) then '/', then ...</param>
            /// <param name="assembly">If null, then use calling assembly to find the resource</param>
            /// <returns></returns>
            public static StreamResourceInfo GetResourceStreamInfo(string path, Assembly assembly = null)
            {
                if (assembly == null)
                {
                    assembly = Assembly.GetCallingAssembly();
                }
    
                return Application.GetResourceStream(GetLocationUri(path, assembly));
            }
    
            // ******************************************************************
            public static Stream GetResource(Uri uri)
            {
                return System.Windows.Application.GetResourceStream(uri).Stream;
            }
    
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
                    using (var reader = new System.Resources.ResourceReader(stream))
                    {
                        DebugPrintResources(reader);
    
                        string resType;
                        byte[] resData = null;
                        try
                        {
                            reader.GetResourceData(path.ToLower(), out resType, out resData);
                        }
                        catch (Exception ex)
                        {
                           
                        }
    
                        if (resData != null)
                        {
                            resStream = new MemoryStream(resData);
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
    
            // ******************************************************************
    
        }
    }
