    protected void Button1_Click(object sender, EventArgs e)
    {
        WebApplication2.WebReference.SMFAdmin ws = new WebApplication2.WebReference.SMFAdmin();
        ListBox1.Items.Add("Request Submitted");
        ListBox1.Items.Add("" + ws.getCountRegisteredSubscribers());
        ListBox1.Items.Add("" + ws.getSubscribers("subname"));
        List<string> lstOutput = new List<string>();
        lstOutput = ws.getSubscribers("subname");
        lstOutput.ForEach(eachItem => ListBox1.Items.Add(eachItem));
    }
