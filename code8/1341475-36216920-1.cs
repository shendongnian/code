    //-- declared at form level
    private Dictionary<string, string> KeywordLookup;
    private void Form1_Load(object sender, EventArgs e)
    {
        //-- ensure that you have all the keywords & values in the dictionary before calling this method.
        KeywordLookup = new Dictionary<string, string>();
        KeywordLookup.Add("CustName", "Pradeep");
        KeywordLookup.Add("BillTotal", "$100.00");
    }
    private void button1_Click(object sender, EventArgs e)
    {
         //-- demo usage
        var s = "Dear {CustName}, Thank you for visiting Here. Your Bill Amount is : {BillTotal}";
        MessageBox.Show(getFinalSMSString(s));
    }
