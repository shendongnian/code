    public void SomeFunciton()
        {
            if(VisualStudioUtility.IsRunningInVisualStudio == false)
            {
                
            }
        }
     static class VisualStudioUtility
    {
        private const string IDE_EXE = "devenv.exe";
        public static bool IsRunningInVisualStudio
        {
            get
            {
                return Environment.CommandLine.Contains(IDE_EXE);
            }
        }
    }
