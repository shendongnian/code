    public partial class WebForm1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
				 if (TextBox1.Text == string.Empty)
				 {
					 PopulateTextBoxes();
				 }
		}
		private void PopulateTextBoxes()
		{
				var li = new ListItem()
				{
					Text = "Item1"
				};
				bulletList.Items.Add(li);
		}
	}
