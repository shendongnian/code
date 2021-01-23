    //TODO: do you really want to compute vowels count on Form Load? Not on rtbDoc.TextChanged?
    private void Form1_Load(object sender, EventArgs e) {
      String text = rtbDoc.Text;
    
      // Finally, formatting which is more readable
      //DONE: you've probably want to assign to Text, not to TextChanged
      toolStripStatusLabel1.Text = 
        String.Format("{0} Characters, of which {1} are vowels.", 
                      text.Length,
                      text.Count(c => IsVowel(c)));
    }
