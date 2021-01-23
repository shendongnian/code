    public Tuple<string, int> UpdateMapFetcher(int stationID, int typeID) {
        if (finaloutput == "System.String")
        {
            // param1[i] = Convert.ChangeType(typeID_New.ToString(), typeof(string));
            returnvalue = returnvalue.ToString();
            return new Tuple<string, int>(returnvalue, 0);
        }
        else if (finaloutput == "System.Int32")
        {
            int a=0;
            a = Convert.ToInt32(returnvalue);
            return new Tuple<string, int>(null, a);
        }
    }
