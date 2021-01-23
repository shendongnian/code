    private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
    {
        List<string> filesToDrag = new List<string>();
        foreach (var item in listView1.SelectedItems)
        {
            filesToDrag.Add(item.ToString().Trim());
        }
        this.listView1.DoDragDrop(new DataObject(DataFormats.FileDrop,
                                    filesToDrag.ToArray()), DragDropEffects.Copy);
    }
