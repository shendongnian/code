    public class ApplicationInstanceProvider : IApplicationInstanceProvider {
        public bool CreateNewProcess() {
            Process process = new Process();
            process.StartInfo.FileName = ResolveApplicationPath();
            return process.Start();
        }
    
        protected virtual string ResolveApplicationPath() {
            return System.Reflection.Assembly.GetEntryAssembly().Location;
        }
    }
