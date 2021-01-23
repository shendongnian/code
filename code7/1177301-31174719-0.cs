	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			listView1.View = View.Details;
			listView1.Columns.Add("Qty", 100, HorizontalAlignment.Left);
			listView1.Columns.Add("Description", 100, HorizontalAlignment.Left);
			listView1.Columns.Add("Prie", 100, HorizontalAlignment.Left);
			var details = new[] {"Widget", "2.95"};
			var item = new ListViewItem("1");
			item.SubItems.AddRange(details);
			listView1.Items.Add(item);
			details = new[]{ "Widget add on",".25"};
			item = new ListViewItem("");
			item.SubItems.AddRange(details);
			listView1.Items.Add(item);
		}
	}
