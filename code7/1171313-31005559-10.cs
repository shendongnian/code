    public interface IAssemblyResolver {
        string GetEntryAssemblyPath();
    }
    public sealed class DefaultAssemblyResolver : IAssemblyResolver {
        public string GetEntryAssemblyPath() {
            return System.Reflection.Assembly.GetEntryAssembly().Location;
        }
    }
    public class ApplicationInstanceProvider : IApplicationInstanceProvider {
        public ApplicationInstanceProvider(IAssemblyResolver resolver) {
            _resolver = resolver;
        }
        public bool CreateNewProcess() {
            Process process = new Process();
            process.StartInfo.FileName = _resolver.GetEntryAssemblyPath();
            return process.Start();
        }
        private readonly IAssemblyResolver _resolver;
    }
