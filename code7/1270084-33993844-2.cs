    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      Regex regex = new Regex(@"[^\d]");
      MatchCollection matches = regex.Matches(textBox1.Text);
      if (matches.Count > 0) {
     
    }
}
