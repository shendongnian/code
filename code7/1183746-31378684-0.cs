    private void UpdateTheUI(string statusMsg)
    {
        if (myList.InvokeRequired)
        {
            myList.BeginInvoke(new MethodInvoker(UpdateTheUI,statusMsg));
        }
        else
        {
           DoSomethingMethod(statusMsg);
        }
    }
