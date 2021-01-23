    var errorList = new List<Exception>();
    foreach(var record in records)
    {
        try 
        {
            try
            {
                TrafficLanesCount = Convert.ToByte(ModifiedFDR.GetValue(ModifiedFDR.GetOrdinal("TRAFICLN")));
            }
            catch
            {
                throw new Exception(new string(DOTNumber + " " + "TrafficLanesCount"));
            }
        }
        catch (Exception exp)
        {
            errorList.Add(exp);
        }
    }
