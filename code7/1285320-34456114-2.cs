         OpenFileDialog openFD = new OpenFileDialog();
            openFD.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
    
         if (openFD.ShowDialog() == DialogResult.OK)
            {
                try 
                {
                    string path = Path.GetFileName(openFD.FileName);
                    textpathTB.Text = path;
        
                    using(var str = new StreamWriter(openFD.FileName))
                    {
                          str.Write("Hello!");
                    }
    
                }
    
                catch (Exception e)
                {
                    MessageBox.Show("The path was not correct! Original error:" + e.Message);
    
                }
         }
