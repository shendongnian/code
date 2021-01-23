      public void readOnOpen(string fileName)
            {
                path = fileName;
                if (File.Exists(path))
                {
    
                    // Write to file 
                    textBox1.Text = File.ReadAllText(path);
    
                }
            }
