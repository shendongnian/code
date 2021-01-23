            {
               try
            {
                System.Diagnostics.Process.Start(@"C:\Program Files(x86)\Notepad++\notepad++.exe"); 
              
            }
            catch (Exception)
            {
                MessageBox.Show("Make sure you have the application 
                installed.", "Error", MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
            }
           }
