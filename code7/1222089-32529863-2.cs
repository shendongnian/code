    public string DoThisStuff(string abcd, int faraca)
    {
        string value = string.Empty; 
        sqlsyntaxxxx = new StringBuilder();
        sqlsyntaxxxx.Append("exec dbo.AlphaDawg ");
        sqlsyntaxxxx.Append("'" + faraca + "'");
        _dataSet = RUNSQL(abcd, sqlsyntaxxxx.ToString());
        value = _dataSet.Tables[0].Rows[0]["AZYXIE"].ToString();
        return value;
    }
