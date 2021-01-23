    void Button_Click(object sender, EventArgs e)
    {
        Button senderButton = sender as Button;
        int itemID = -1;
        if (senderButton != null && senderButton.ID.Contains('-'))
        {
            itemID = int.Parse(senderButton.ID.Split('-')[1]); //or int.TryParse (better)
            //work with itemID
        }
    }
