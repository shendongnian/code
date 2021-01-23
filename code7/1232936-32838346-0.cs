     public partial class GUI
    {
        private static GUI _instance;
        public static GUI Instance
        {
            get { return _instance ?? (_instance = new GUI()); }
        }
        public void WriteToLog(string msg)
        {
            //[your code]...
        }
    }
    class FileManager
    {
        internal static void RenameFiles(string filePath)
        {
            GUI.Instance.WriteToLog("Moving Files");
            // [other code]...
        }
    }
