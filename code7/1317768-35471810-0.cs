    List<MyForm> formList = new List<MyForm>();
    readonly object formListLock = new object();
    private void comm_MessageReceived(object sender, MessageReceivedEventArgs e)
    {
        /// you need to lock the List for thread safe access
        lock (formListLock) 
        {
            /// iterate over a copy of the list to avoid mutating the list under iteration
            foreach (MyForm form in formList.ToList())
            {
                form.Close();
            }
        }
        string msg = "message";
        using (MyForm form = new MyForm(msg))
        {
            lock (formListLock) { formList.Add(form); }
            form.ShowDialog();
            lock (formListLock) { formList.Remove(form); }
        }
    }
