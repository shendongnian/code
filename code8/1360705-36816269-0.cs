      public override void Commit(IDictionary savedState)
        {
            string strPath = "";
            var myProcess = new Process();
    
            try
            {
                base.Commit(savedState);
    
                strPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Test");          
                strPath = Path.Combine(strPath, "myApp.exe");          
                myProcess.StartInfo.FileName = strPath;
                myProcess.StartInfo.CreateNoWindow = false;
                myProcess.Start();
                myProcess.WaitForExit(500);
                myProcess.Close();
                myProcess = null;         
            }          
    
            catch (Exception ex)
            {
                MessageBox.Show("public override void Commit  " + ex.ToString());
                Application.Exit();          
            }
        }
