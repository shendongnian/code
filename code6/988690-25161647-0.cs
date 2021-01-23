    public void onDataReceived(Data data)
    {
        if(db.GetAmountOfUserFromDB(data.userID) != null && data.AmountBox != null)
        {
           //just ignore the data.AmountBox value here or react with a message like "It is not allowed to change the amount"
        }
        else
        {
            //add data.AmountBox to db or whatever
        }
    }
