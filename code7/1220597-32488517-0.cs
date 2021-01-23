    public class CacheHelper
    {
      public Dictionary<string, List<ParameterValues>> LoadParameterCache2()
      {
           var objList = new Dictionary<string, List<ParameterValues>>();
            //call the values from the database blah blah
            while (rdr.Read())
            {
                var cacheObj = new ParameterValues();
                cacheObj.ParameterKey = rdr.GetString("PARAMETER_KEY");
                cacheObj.ParameterValue = rdr.GetString("PARAMETER_VALUE");
     //here is where you need to change things.
                var groupCode = rdr.GetString("GROUP_CODE");
                if (objList.ContainsKey(groupCode) == false)
                {
                   objList.Add(groupCode, new List<ParameterValues> {cacheObj});
                }
                else 
                {
                   objList[groupCode].Add(cacheObj);
                }
            }
        return objList; //and finally return it to the main application thread
      }
    }
