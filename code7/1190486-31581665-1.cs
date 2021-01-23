    private void tree_ItemDrag(object sender, ItemDragEventArgs e)
    {
        var node = (e.Item as TreeNode).Tag as DataObject;
        if(!node.IsFrozen)
           DoDragDrop(e.Item, DragDropEffects.Move);
        else
            MessageBox.Show("Frozen nodes cannot be moved", "Drag & Drop error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
