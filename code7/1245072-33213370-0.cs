            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                var ofd = new OpenFileDialog();
                ofd.Multiselect = true;
                DialogResult dr = ofd.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    foreach (String file in ofd.FileNames)
                    {
                        listView1.Items.Add(file);
    
                        getCommandlineResult(file, "path1", "path2");
                    }
                }
             
            }
    
            public string getCommandlineResult(string userSelectedFilesToDecrypt, string UserSelectedFilesAlreadyDecrypted,
                string user_selected_key_file)
            {
                string macAddress = string.Empty;
                System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
                pProcess.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
                pProcess.StartInfo.Arguments = "openssl enc - d - aes - 256 - cbc -in " + userSelectedFilesToDecrypt + ".enc -out " +
                                               UserSelectedFilesAlreadyDecrypted + ".mp3 - pass file:./ " +
                                               user_selected_key_file + ".bin";
                pProcess.StartInfo.UseShellExecute = false;
                pProcess.StartInfo.RedirectStandardOutput = true;
                pProcess.StartInfo.CreateNoWindow = true; //hide window
                pProcess.Start();
                string strOutput = pProcess.StandardOutput.ReadToEnd();
                return strOutput;
            }
