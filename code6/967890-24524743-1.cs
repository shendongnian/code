    foreach (DataRow row in dt.Rows)
        {
            int iRowStatus = Convert.ToInt32(row["status"]);
            int iId = Convert.ToInt32(row["id"]);
            string sName = row["name"].ToString();
            string sPhone = row["phone"].ToString();
            switch (iRowStatus)
            {
                case 1:
                    someFunction(iId,sName);  
                    break;
                case 2:
                    someFunction(iId,sName, sPhone);  
                    break;
            }
        } 
    private void someFunction (int iId, string sName)
    {
         //do something
    }
    private void someFunction (int iId, string sName, string sPhone)
    {
         //do something
    }
    
