    string file = "";            
    private void button1_Click(object sender, EventArgs e)
        {
           int size = -1;
           DialogResult result = openFileDialog1.ShowDialog();
           if (result == DialogResult.OK)
            {
               file = openFileDialog1.FileName;
               try
               {
                  string text = File.ReadAllText(file);
                  size = text.Length;
                  textBox1.Text = file; // for full location
                  textBox2.Text = Path.GetFileName(Path.GetDirectoryName(file)); // for last folder name
               }
               catch (IOException)
               {
               }
           }
        }
                
