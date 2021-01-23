    List<string> list = new List<string>();
    foreach(var textBox in Controls.OfType<TextBox>())
    {
      if(!string.IsNullOrEmpty(textBox.Text))
      {
        list.Add(textBox.Text);
      }
    }
    string[] textBoxValues = list.ToArray();
