    DateTime pendingDateTime;
    if(!DateTime.TryParse(TxtPendingDateTime.Text, out pendingDateTime))
    {
        MessageBox.Show("Please enter a valid Pending-Date in the format: yourformat");
        return;
    }
    // here you can go on with the code above
