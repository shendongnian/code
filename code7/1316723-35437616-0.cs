    lstMail.Items.Add(new ListViewItem(new string[]
    {
        "",                                                    //From Column
        allMessages[countMsg].Headers.Subject,                 //Subject Column
        allMessages[countMsg].Headers.DateSent.ToString()      //Date Column
    }));
