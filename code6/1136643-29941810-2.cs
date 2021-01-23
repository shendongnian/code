    interface IOptionsProvider {
        ProcessOptionsModel GetProcessOptions();
    }
    class ProcessOptionsView : IOptionsProvider {
        public ProcessOptionsModel GetProcessOptions() {
             if (this.ShowDialog()) {
                  return this.ModelView.Model;
             }
             return null;
        }
    }
    class ProcessOptionsFromFile : IOptionsProvider {
        public ProcessOptionsModel GetProcessOptions() {
             // Create an instance of ProcessOptionsModel from File
        }
