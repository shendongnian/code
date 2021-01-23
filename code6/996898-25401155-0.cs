    private void NameOfMethodToRunAsynchronously()
    {
        // Some long running process
        Dispatcher.Invoke((System.Action)delegate()
        {
            //Add some item in a ListBox, this ListBox is defined in the user control.
            TextBlock b = new TextBlock();
            //some code
            Listbox.Items.Add(b);
        }
    }
