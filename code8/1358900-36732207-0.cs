    private void firstlabel()
    {
        doDisplayUpdate("klg");
        Thread.Sleep(500);
        doDisplayUpdate("Saving");
        Thread.Sleep(500);
        doDisplayUpdate("Saving.");
        Thread.Sleep(500);
        doDisplayUpdate("Saving..");
        Thread.Sleep(500);
        doDisplayUpdate("Done");
    }
    private delegate void doDisplayUpdateDelegate(string result);
    private void doDisplayUpdate(string text)
    {
        if (label2.InvokeRequired)
        {
            label2.Invoke(new doDisplayUpdateDelegate(doDisplayUpdate), text);
        }
        else
        {
            label2.Text = text;
        }
    }
    ...
    ...
    label2.Visible = true;
    Thread ms = new Thread(new ThreadStart(firstlabel));
    ms.Start();
