    List<string> lstItems=new List<string>(){"item1",...}; //The items list
    private void Textbox1_TextChanged(object sender, EventArgs e)
    {
      ComboBox1.Items.Clear();
      foreach(string s in lstItems.Where(s=> s.Contains(TextBox1.Text)))
       ComboBox1.Items.Add(s);
    }
