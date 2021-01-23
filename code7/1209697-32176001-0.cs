    XDocument doc = XDocument.Load("TimeLog.xml");
    if (doc.Root.Name == "TimeLog")
    {
        // ...
    }
    else
    {
        MessageBox.Show("This is not a TimeLog XML file", "This is not a TimeLog XML file", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
    }
