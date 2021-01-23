    DateTime pendingDateTime;
    if(!DateTime.TryParse(TxtPendingDateTime.Text, out pendingDateTime)
    {
        MessageBox.Show("error ...");
        return;
    }
    // here you can go on with the code above
