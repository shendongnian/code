    public void AddItem(object item)
    {
      comboBox1.Items.Add(item);
      Form2 f = new Form2(this);
      f.Show();
    }
        
