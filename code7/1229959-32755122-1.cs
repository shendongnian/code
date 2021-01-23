    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // demo values
            for (int i = 0; i < 10; i++)
            {
                ListBox1.Items.Add("value " + i);
            }
            
        }
    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Debug.WriteLine(ListBox1.SelectedItem);
    }
