    protected void btnRace_Click(object sender, EventArgs e)
    {
        // Should not be required but....
        if(UserClick != null)
        {
            UserClick.BtnClicks++;
            // The integer is meaningless in the context of your code above
            // It could be removed because the Add logic is driven 
            // by BtnClicks value
            UserClick.Add(0);
        }
    }
