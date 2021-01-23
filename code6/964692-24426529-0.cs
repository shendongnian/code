    protected void Button1_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        if (btn.Text=="Button1")
        {
            Response.Write("button1");
            //button 1 logic goes here
        }
        else if (btn.Text =="Button2")
        {
            Response.Write("button2");
            //button 2 logic goes here
        }
        else
        {
            Response.Write("button3");
            //button 3 logic goes here
        }
    }
