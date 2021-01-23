        public void SettingsButton(object sender, RoutedEventArgs e)
            {
                var dialog = new System.Windows.Forms.FolderBrowserDialog();
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
        
                if (result == System.Windows.Forms.DialogResult.OK)
                {    
                    string[] files = Directory.GetFiles(dialog.SelectedPath);
        
                    string resultStr = string.Empty;
                    foreach (String item in files)
                    {
                        resultStr += item.ToString() + "\n";
                    }
        
                    MessageBox.Show("path:" + dialog.SelectedPath + "\n" + 
                                    "files: " + files.Count().ToString() + "\n" + 
                                     resultStr, "Message");
                }
            }
