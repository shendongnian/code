    Entity.Transactions.POCDANumberTracking temp;
    foreach (Entity.Transactions.POCDANumberTracking returnItem in returnRejectList)
    {
        var code = returnItem.Code.Trim();
        var grnNo = returnItem.GrnNo.Trim();
        var wbcNo = returnItem.WbcNo.Trim();
        for (int i = returnItem.From; i <= returnItem.To; i++)
        {
            temp = new SalesOrderModule.Entity.Transactions.POCDANumberTracking();
            temp.From = i;
            temp.To = i;
            temp.Code = code;
            temp.GrnNo = grnNo;
            temp.WbcNo = wbcNo;
            returns.Add(temp);
         }
     }
