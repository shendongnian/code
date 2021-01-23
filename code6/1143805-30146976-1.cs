    public partial class DynamicUC : UserControl
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            public void PopulateData(string value)
            {
                tbMyTextBox.Text = value;
                gvNumbers.DataSource = Enumerable.Range(1, 5).Select(i => new { Serial = i, Item = "Item " + i });
                gvNumbers.DataBind();
            }
    
            public string GetData()
            {
                return Server.HtmlEncode(tbMyTextBox.Text);
            }
        }
