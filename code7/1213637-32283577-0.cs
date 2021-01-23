    protected void Button1_Click(object sender, EventArgs e)
    {
        wbRfrnc.TransactionPut obj =new wbRfrnc.TransactionPut();
        string result = obj.GetPoint(TextBox1.Text, TextBox2.Text);
        var objGD = JsonConvert.DeserializeObject<GetData[]>(result);
        Response.Write(objGD[0].Response); 
    }
