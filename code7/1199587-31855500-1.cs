    private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
      if (bChanging) return;
      bChanging = true;
      listbox2.ClearSelected();
      bChanging = false;
    } 
