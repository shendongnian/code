    public class ItemMenu : ContextMenuStrip
    {
        public event EventHandler AddNewItem;
        public ItemMenu (IContainer container)
            : base(container)
        {
            MenuItemAdd = new ToolStripMenuItem("Add", null, AddNew);
            this.Items.AddRange(new ToolStripItem[] 
            { 
                mnuAdd, 
            });
        }
        public void AddNew(object sender, EventArgs e)
        {
            EventHandler handler = AddNewItem;
            if (handler != null)
            {
                handler(sender, e);
            }
            else
            {
                OnAddNew(sender, e);
            }
        }
        protected void OnAddNew(object sender, EventArgs e)
        {
            //Code to add new item here...
        }
    }
