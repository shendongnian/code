    private void Form1_Load(object sender, EventArgs e)
        {
            using (StreamReader settingsReader = new StreamReader(@"C:\path\to\file\filename.ending"))
            {
                LoadFieldColors(settingsReader);
            }
            ApplyDefaultColorToControls(this);
        }
               private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter settingsWriter = new StreamWriter(@"C:\path\to\file\filename.ending"))
            {
                SaveFieldColors(this, settingsWriter);
            }
        }
    }
  
