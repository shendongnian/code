     protected void Page_Load(object sender, EventArgs e)
    {
            
            createDynamicLabels();
    }
    private void createDynamicLabels()
        {
            int n = 5;
            for (int i = 0; i < n; i++)
            {
                Label MyLabel = new Label();
                MyLabel.ID = "lb" + i.ToString();
                MyLabel.Text = "Labell: " + i.ToString();
                MyLabel.Style["Clear"] = "Both";
                MyLabel.Style["Float"] = "Left";
                MyLabel.Style["margin-left"] = "100px";
                Panel1.Controls.Add(MyLabel);
            }
        }
    protected void bReadDynValue_Click(object sender, EventArgs e)
    {
        int n = 5;
        for (int i = 0; i < n; i++)
        {
            Label str = (Label)Panel1.FindControl("lb" + i.ToString());
            lbGetText.Text = str.Text;
        }
    }
