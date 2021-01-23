    private void DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            //Get arguments we passed in onclick event
            Object[] arg = e.Argument as Object[];
            
            //Do stuff for multiline value - which is via (string)arg[0]
            string[] delimiter = { Environment.NewLine };
            string _deliverynumbers = (string)arg[0];
            string[] array_deliverynumbers = _deliverynumbers.Split(delimiter, StringSplitOptions.None);
            
            //Generate Indexing
            int count = array_deliverynumbers.Length;
            int current = 0;
            //ForEach Line in multiline TextBox
            foreach (string text in array_deliverynumbers)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(text)))
                {
                    
                    //Update Indexing
                    current++;
                    //Determine Progress bar percentage
                    Double Total_Percentage = count;
                    Double Current_Percentage = current;
                    Double progressAmount = (Current_Percentage / Total_Percentage * 100);
                    //Copy source file for each line in TextBox & rename new copied file to the line value & source file format
                    string new_filename = text.Substring(2, text.Length - 2);
                    string sourceFile = (string)arg[1];
                    string destinationPath = (string)arg[2];
                    string destinationFileName = new_filename + System.IO.Path.GetExtension(sourceFile);
                    string destinationFile = System.IO.Path.Combine(destinationPath, destinationFileName);
                    
                    //Check Folder exists
                    if (!System.IO.Directory.Exists(destinationPath))
                    {
                        System.IO.Directory.CreateDirectory(destinationPath);
                    }
                    //Copy & Move and rename
                    System.IO.File.Copy(sourceFile, destinationFile, true);
                    //Sleep for a bit incase processing is to quick
                    Thread.Sleep(100);
                    
                    //Update progress bar with new amount                    
                    backgroundWorker.ReportProgress(Convert.ToInt32(progressAmount));
                }
            }
            
        }
