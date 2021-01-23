	public partial class Form1 : Form
	{
		Form3 form3 = null;
		public Form1()
		{
			InitializeComponent();
		}
    /*	private void Form1_Load(object sender, EventArgs e)
		{
	//You won't need this. It just populates my 
	//listview with some Dummy Data. I'll leave
	//it here in case you want to mess with it
			for (int i = 0; i < 10; i++)
			{
				var lv = new ListViewItem();
				lv.Text = "Item" + i;
				lv.SubItems.Add((6+ i).ToString());
				lv.SubItems.Add((i + 7).ToString());
				lv.SubItems.Add((i + 3).ToString());
				listView1.Items.Add(lv);
			}
		}*/
		//public int Index; //not needed
		private void button3_Click(object sender, EventArgs e)
		{
			form3 = new Form3();
			if (listView1.SelectedItems.Count > 0)
			{
				//this.listView1.Items[0].Focused = true;
				//this.listView1.Items[0].Selected = true;
				//this.Index = listView1.FocusedItem.Index;
				//ListViewItem selecteditem = listView1.SelectedItems[0];
				form3.GetData(listView1.FocusedItem.Text, listView1.FocusedItem.SubItems[1].Text,
								listView1.FocusedItem.SubItems[2].Text, listView1.FocusedItem.SubItems[3].Text);
				DialogResult ans = form3.ShowDialog();
				if (ans == DialogResult.OK)
				{
					listView1.FocusedItem.Text = form3.Prozz;
					listView1.FocusedItem.SubItems[1].Text = form3.Kolii;
					listView1.FocusedItem.SubItems[2].Text = form3.Cenaa;
					listView1.FocusedItem.SubItems[3].Text = form3.Proff;
				}
			}
			form3 = null;
		}
	}
