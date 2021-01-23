    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        try
        {
            if (listBoxSnap.IsHandleCreated)
            {
                listBoxSnap.Invoke(new MethodInvoker(delegate { this.listBoxSnap.Items.Add("Minimized Windows"); }));
                listBoxSnap.Invoke(new MethodInvoker(delegate { this.listBoxSnap.Items.AddRange(WindowSnap.GetAllWindows(true, true).ToArray()); }));
            }
        }
        catch (Exception ee)
        {
            string t = "exception " + ee.ToString();
        }
    }
