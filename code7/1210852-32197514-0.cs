            SaveFileDialog save = new SaveFileDialog();
         // save.FileName = "Parameters.txt";
            save.Filter = "Text File | *.txt";
           if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
           {
               using (System.IO.StreamWriter File = new System.IO.StreamWriter(save.FileName))
               {
                   File.Write("===========parameters===========" + "\r\n");
                   File.Write("Number of teeth: " + "\r\n");
                   // File.Close();
                   MessageBox.Show("Saving succeed(Parameters)");
               }
            }
