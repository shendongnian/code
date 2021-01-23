    task = TaskOptions.Print | TaskOptions.Save;
    if ((task & TaskOptions.Print) == TaskOptions.Print)
    { 
        print();
    }
    if ((task & TaskOptions.Save) == TaskOptions.Save)
    { 
        save();
    }
    if ((task & TaskOptions.SendMail) == TaskOptions.SendMail)
    { 
        sendMail();
    }
