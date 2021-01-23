    private void Form1_Load(object sender, EventArgs e)
    {
        SetValuesOnSubItems(this.menuStrip1.Items.OfType<ToolStripMenuItem>().ToList());
    }
    private void SetValuesOnSubItems(List<ToolStripMenuItem> items)
    {
        items.ForEach(item =>
                {
                    var dropdown = (ToolStripDropDownMenu)item.DropDown;
                    if (dropdown != null)
                    {
                        dropdown.ShowImageMargin = false;
                        SetValuesOnSubItems(item.DropDownItems.OfType<ToolStripMenuItem>().ToList());
                    }
                });
    }
