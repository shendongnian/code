    namespace MyApplication.Domain
    {
        [System.Diagnostics.DebuggerDisplay("ID = {ID}, GroupName = {GroupName}, Value='{Value}'")]
        public partial class MyDto
        {
            public int ID { get; set; } /* PK */
            public string GroupName { get; set; }
            public string Value { get; set; }
        }
    }
    
    
    
        try
        {
    
            List<MyDto> dtoCollection = new List<MyDto>();
    
    	
            foreach (GridViewRow row in gvDetails.Rows)
            {
              string  strID = ((Label)row.FindControl("lblID")).Text;
              string  strGroup = ((Label)row.FindControl("lblGrp")).Text;
               string strValue = ((TextBox)row.FindControl("txtValue")).Text;   
    
    MyDto newItem = new Dto() {ID = Convert.ToInt32(strID), Group = strGroup, Value = strValue};
    
    dtoCollection.Add(newItem);  
            }
    
    int count = dtoCollection.Count;
    /* now send your dtoCollection to your BusinessLayer ... have your businesslayer validate the input data......then have the business layer call your datalayer...and use the List<MyDto> objects to update your database */
    
        }
        catch (Exception ex)
        {
    
        }
