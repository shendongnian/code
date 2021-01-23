    private void button4_Click(object sender, EventArgs e)
    {
      AddText at = new AddText(this);
      at.Show();
      richTextBox2.Text = at.text;
    }
    
    public void SetText(string text)
    {
      richTextBox2.Text = text;
    }
