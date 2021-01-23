    protected void btnOrder_Click(object sender, EventArgs e)
    {
        bool isHungry = rdbHungry.Checked;
        string menuItem = rdbMenu.SelectedItem.Text;
        string url = String.Format("Result.aspx?isHungry={0}&menuItem={1}", isHungry, menuItem);
        Response.Redirect(url);
    }
