      private void btnRead_Click(object sender, EventArgs e)
            {
                string assemblyName = Assembly.GetExecutingAssembly().Location;
                string assemblyDirectory = Path.GetDirectoryName(assemblyName);
                m_readFile = new StreamReader (assemblyDirectory + @"\" + "MyDataFile.txt");
        
        
                int counter = 1;
                string line;
        
                 while ((line = m_readFile.ReadLine()) != null)
                 {
                    string col = line.Split(' ')[2];
                    MessageBox.Show(line);            
                    counter++;
                }
        
                m_readFile.Close();
            }
