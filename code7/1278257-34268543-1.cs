    private void AppendLine(string lineToAdd)
    {
        if(InvokeRequired) //if we are not on the gui thread
        {
            //re-call the same method on the gui thread
            LineAppenderDelegate d = new LineAppenderDelegate(AppendLine);
            Invoke(d, new object[]{lineToAdd});
        }
        else //we are on the gui thread and can just do the work
        {
            Lines.Text += lineToAdd;
        }
    }
