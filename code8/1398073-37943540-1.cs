       public DataTable returnAddressList(string postcode, string accessCode, XmlTextReader reader)
        {
            try
            {
                DataTable dtReturn = new DataTable();
                dtReturn.Columns.Add("PropertyItem", Type.GetType("System.String"));
                dtReturn.Columns.Add("PropertyValue", Type.GetType("System.String"));
    
                postcode = postcode.Replace(" ", "");
               
    
                string option1 = "";
                string option2 = "";
