    private void Form1_Load(object sender, EventArgs e)
    {
      char[] vowelSet = { 'a', 'e', 'i', 'o', 'u' };
      int vowels = 0;
      int characters = 0;
      foreach(char c in rtbDoc.Text.ToLower())
      {
        characters+=1;
        if (vowelSet.Contains(c))
        {
            vowels += 1;
        }
      }
    
      toolStripStatusLabel1.TextChanged = characters + 
                          "Characters, of which " + vowels + " are vowels";
    }
