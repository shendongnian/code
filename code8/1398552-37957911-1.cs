    public void Button_Click(object sender, EventArgs e)
    {
        if (Session["x"] != null)
        { 
            // do processing
    
            // in the end, store value for future use
            Session["x"] = myLabel.Text;
        }
    }
