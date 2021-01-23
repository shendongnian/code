    protected void Button1_Click(object sender, EventArgs e) 
    {
            string clickedButton = "Button1";
            Turn = Turn + 1;
            Response.Redirect(string.Format("TheGame.aspx?button={0}&turn={1}", clickedButton , Turn)); 
    }
