    int index = listBox1.IndexFromPoint(e.Location);
    if (index != System.Windows.Forms.ListBox.NoMatches)
    {
      System.Console.WriteLine(listBox1.SelectedItem.ToString()); //console for testing
    }
