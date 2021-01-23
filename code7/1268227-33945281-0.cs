    protected void Repeater1_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       
        {
            //assigns a temporary variable the value of the control we find.
            Label nullPris = (Label)e.Item.FindControl("PrisLabel");
            Label nullHeight = (Label)e.Item.FindControl("HeightLabel");
            Label nullWidth = (Label)e.Item.FindControl("WidthLabel");
            //Checks if the lable has the text we're looking for.
            if (nullPris.Text == "0,00 Kr.-" || nullPris.Text == "0.00 Kr.-")
            {
                //If it has, stop rendering the label.
                nullPris.Visible = false;
            }
            if (nullHeight.Text == "Højde: 0,00 cm" || nullHeight.Text == "Højde: 0.00 cm")
            {
                //If it has, stop rendering the label.
                nullHeight.Visible = false;
            }
            //Checks if the lable has the text we're looking for.
            if (nullWidth.Text == " Bredde: 0,00 cm" || nullWidth.Text == "Bredde: 0.00 cm")
            {
                //If it has, toggle the visibility..
                nullWidth.Visible = false;
            }
        }
    }
