	var parameters = new List<SqlParameter> {
		new SqlParameter("@DateParam", dateQueryString),
		new SqlParameter("@LineCode", chartModelData.LineCode),
		new SqlParameter("@ModelNumber", chartModelData.ModelNum),
		new SqlParameter("@EquipNumber", equipmentNumber),
		new SqlParameter("@LotNumber", chartModelData.LotNum)	
	}
	var dateParameters = chartModelData.GetFormattedDateList()
		.Select((d, i) => new SqlParameter("@date" + i, d));
		
	var queryFormat = @"SELECT MAX(DATA_SEQ) AS MaxSeq, 
       MIN(DATA_SEQ) AS MinSeq, 
       COUNT(1) AS TotSampleCnt
	   FROM SPCDATA_TB
	   WHERE DATA_WDATE IN ({0})  
	   AND LINE_CODE = @LineCode
	   AND MODEL_NO = @ModelNumber
	   AND LOT_NO = @LotNumber
	   AND EQUIP_NO LIKE @EquipNumber";
	   
	var query = string.Format(queryFormat, 
        string.Join(",", dateParameters.Select(p => p.ParameterName)));
	parameters.AddRange(dateParameters);
	var myResult = _dbContext.Database.SqlQuery<SPCDataSeqCntInfo>(
        query, 
        parameters.ToArray());
