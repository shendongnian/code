    private void MenuItem_Clicked(object sender, ToolStripItemClickedEventArgs e)
    {
      Console.WriteLine("Clicked {0}", e.ClickedItem.Name);
    }
    private void SubItem_Click(object sender, EventArgs e)
    {
      Console.WriteLine("Clicked {0}", (sender as ToolStripMenuItem).Name);
    }
