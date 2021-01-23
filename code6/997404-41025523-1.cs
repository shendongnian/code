    string[] mMessage = e.Entry.Message.Split(new string[] { "\r\n" }, StringSplitOptions.None);
    for (i=0; i<=mMessage.count; i++)
    {
        if (mMessage[i] == "Account Domain") 
        {
           Console.WriteLine(mMessage[i]);
        }
    }
