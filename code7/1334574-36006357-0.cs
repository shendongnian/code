    var reader = com.ExecuteReader();
    if (reader.HasRows) {
        while (reader.Read()) {
            Dictionary<String, String> objDic = new Dictionary<string, string>(); // MOVED!
            string CommissionDealerId = reader[0].ToString();
            string Month = reader[1].ToString();
            string DealerCommissionType = reader[2].ToString();
            string CommissionCount = reader[3].ToString();
            string CommissionAmount = reader[4].ToString();
            objDic["CommissionDealerId"] = CommissionDealerId;
            objDic["Month"] = Month;
            objDic["DealerCommissionType"] = DealerCommissionType;
            objDic["CommissionCount"] = CommissionCount;
            objDic["CommissionAmount"] = CommissionAmount;
            listDic.Add(objDic);
        }
    }
