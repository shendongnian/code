    BindingList<byte[]> myList; //Your binding list
    byte[] newItem = myList.AddNew();
    foreach (var item in AudioStreams)
    {
        if (item.AudioStream == newItem)
        {
            //We ask the BindingList to remove the last inserted item
            myList.CancelNew(myList.IndexOf(newItem));
        }
    }
    //We validate the last insertion.
    //If last insertion has been cancelled, the call has no effect.
    myList.EndNew(myList.IndexOf(newItem));
