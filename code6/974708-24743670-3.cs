    {
        private void ShowExportDialog(ExampleSaveableClass myClass)
        {
            var dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.Title = "Filename and Location to Export Sample Objects";
            dlg.FileName = "MySavedObjects"; // Default file name
            dlg.DefaultExt = ".json"; // Default file extension
            dlg.Filter = "JSON documents (.json)|*.json"; // Filter files by extension
            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            // Process save file dialog box results
            if (result == true)
            {
                string str = myClass.ToJsonString();
                System.IO.File.WriteAllText(dlg.FileName, str, Encoding.UTF8);
            } 
         
        }
        public static ExampleSaveableClass ImportSavedClass()
        {
            //Pseudo obtain filename...
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Event"; // Default file name
            dlg.DefaultExt = ".json"; // Default file extension
            dlg.Filter = "JSON documents (.json)|*.json"; // Filter files by extension
            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            // Process open file dialog box results
            if (result != true)
            {
               return null;
            }
            string filename = dlg.filename;
            ExampleSaveableClass loadedSaveableClass = null;
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.Open);
                var ds = new DataContractJsonSerializer(typeof(ExampleSaveableClass));
                loadedSaveableClass = (ExampleSaveableClass)ds.ReadObject(fs);
            }
            finally
            {
                if(null != fs)
                {
                    fs.Close();
                }
            }
            return loadedSaveableClass;
        }
    }
