    string filename = "file.txt";
            PrintDialog pd = new PrintDialog();
            if (File.ReadAllText(filename).Count() > 0)
            {
                //printer setting should be applied using this file
                //read the filename line by line and apply the setting
                pd.PrinterSettings.PrinterName=""; //line 1 of file..
                .
                .
                .
                .
            }
            else
            {
                
                DialogResult result = pd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(filename);
                    sw.WriteLine(pd.PrinterSettings.PrinterName);
                 
                    .
                    .
                    .
                    .
                    sw.Close();
                }
            }
