    class MyObject
    {
        private static ContextMenuStrip sharedPopup;
        public static ContextMenuStrip SharedPopup
        {
            get
            {
                if (null == sharedPopup)
                {
                    sharedPopup = new ContextMenuStrip();
                    ToolStripMenuItem deleteItem = new ToolStripMenuItem();
                    deleteItem.Click += ItemDelete_Click;
                    deleteItem.Paint += deleteItem_Paint;
                    sharedPopup.Items.Add(deleteItem);
                }
                return sharedPopup;
            }
        }
        static void deleteItem_Paint(object sender, PaintEventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            item.Text = "Delete " + ((item.Owner as ContextMenuStrip).SourceControl as TreeView).SelectedNode.Text;
        }
        public MyObject(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        static void ItemDelete_Click(object sender, EventArgs e)
        {
        }
    }
