    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    
    namespace MokPoc
    {
        internal class Program
        {
               private static void Main(string[] args)
               {
                    var students = new ReadStudentsService();
                    string results = students.GetStudentXml();
                    string contacts = students.GetTelephoneXml();
               }
        }
        public class ReadStudentsService
        {
            private const string ProgramFilesZooskDirectory = @"C:\Program Files\Zoosk";
            private const string SimsProcessesTppersonstudent = "SIMS.Processes.TPPersonStudent";
            public string GetStudentXml()
            {
                return GetStudentAttributes("ThirdPartyProcesses.dll", "GetXmlStudents");
            }
            public string GetTelephoneXml()
            {
                return GetStudentAttributes("ThirdPartyContacts.dll", "GetXmlTelephone");
            }
            public string GetStudentAttributes(string dllToUse, string methodToExecute)
            {
                var fullpath = Path.Combine(ProgramFilesZooskDirectory, dllToUse);
                var args = new object[] {DateTime.Today};
                var assemblyToLoad = Assembly.LoadFrom(fullpath);
                var typeToLoad = assemblyToLoad.GetType(SimsProcessesTppersonstudent);
                var methodToInvoke = typeToLoad.GetMethod(methodToExecute, args.Select(o => o.GetType()).ToArray());
                var obj = Activator.CreateInstance(typeToLoad);
                return (string) methodToInvoke.Invoke(obj, args);
            }
        }
    }
