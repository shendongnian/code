    protected void Button1_Click(object sender, EventArgs e)
    {
        List<GetData> data= new List<GetData>();
        wbRfrnc.TransactionPut obj =new wbRfrnc.TransactionPut();
        string result = obj.GetPoint(TextBox1.Text, TextBox2.Text);
        data = JsonConvert.DeserializeObject<List<GetData>>(result);
        if(data.Any())
          Response.Write(data.First().Response); 
    }
