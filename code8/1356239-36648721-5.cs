    private void Form1_Load(object sender, EventArgs e) {
      String text = rtbDoc.Text;
    
      // Finally, formatting which is more readable
      toolStripStatusLabel1.TextChanged = 
        String.Format("{0} Characters, of which {1} are vowels.", 
                      text.Length,
                      text.Count(c => IsVowel(c)));
    }
