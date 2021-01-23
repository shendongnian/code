    public class MyClass
    {
        private string selectedPath = "";
        public void Export(int formatVersion, bool pureXmlDriver)
        {
            if (Device != null)
            {
                Utilities.StripShortNameFromLongNames(Device);
                using (var folderBrowser = new FolderBrowserDialog())
               {
                   folderBrowser.Description = Resources.SelectExportFolder;
                   folderBrowser.SelectedPath = selectedPath;
                   if (folderBrowser.ShowDialog() == DialogResult.OK)
                   {
                       selectedFolder = folderBrowser.SelectedPath;
                       try
                       {
                           Cursor = Cursors.WaitCursor;
                           HandleExport(formatVersion, pureXmlDriver, selectedFolder);
                       }
                       finally
                       {
                           Cursor = Cursors.Default;
                       }
                   }
               }
           }
       }    
    }
