    private Lazy<ToolStripMenuItem> _itemDelete =
        new Lazy<ToolStripMenuItem>(() => _CreateItemDelete());
    private ToolStripMenuItem _CreateItemDelete()
    {
        ToolStripMenuItem itemDelete = new ToolStripMenuItem("Delete " + name);
        itemDelete.Enabled = Deletable;
        itemDelete.Image = Properties.Resources.del;
        itemDelete.Click += ItemDelete_Click;
        return itemDelete;
    }
    public ToolStripMenuItem ItemDelete
    {
        get
        {
            return _itemDelete.Value;
        }
    }
