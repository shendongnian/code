    public partial class Form1 : Form
	{
        //...
		Stack<TabPage> breadCrumbs = new Stack<TabPage>();
		private void SwitchTabs(TabPage page)
		{
			breadCrumbs.Push(tabControl1.SelectedTab);
			tabControl1.SelectedTab = page;
		}
		//...
        //Go back
		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			if(breadCrumbs.Count == 0)
				return;
			var lastTab = breadCrumbs.Pop();
			tabControl1.SelectedTab = lastTab;
		}
	}
