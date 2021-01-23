    using System.Diagnostics;
    using System.ServiceModel;
    
    namespace WcfService1
    {
        [ServiceContract]
        public interface IService1
        {
            [OperationContract]
            string RunTally();
        }
    
        public class Service1 : IService1
        {
            public string RunTally()
            {
                var tallyPath = "C:\\temp\\";
                var tallyExe = "tally.exe";
                var cmpCode = "myCmpCode";
                var uname = "myUname";
                var pwd = "myPwd";
                var tdlPath = "myTdlPath";
    
                Process proc = new Process();
                ProcessStartInfo info = new ProcessStartInfo();
                info.WindowStyle = ProcessWindowStyle.Hidden;
                info.RedirectStandardOutput = true;
                info.RedirectStandardInput = true;
                info.RedirectStandardError = true;
                info.UseShellExecute = false;
                info.Arguments =
                    // "\"" + tallyPath + "\"" + "  "
                     // +
                     "/TDL:" + tdlPath + " " + "/LOAD:"
                     + cmpCode + "  " + "/SETVAR:SVVarUN:"
                     + uname + " " + "/SETVAR:SVVarPass:"
                     + pwd;
                info.FileName = tallyPath + tallyExe;
    
                proc.StartInfo = info;            
                proc.Start();
    
                var textReceived = "";
                while (!proc.StandardOutput.EndOfStream)
                {
                    textReceived += proc.StandardOutput.ReadLine();
                }
    
                return string.Format("The call returned: " + textReceived);
            }
        }
    }
