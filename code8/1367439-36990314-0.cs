        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json, UseHttpGet = true)]
        public static string GetDetails(int ID)
        {
           PDetails PDetails = new PDetails();
           OrderManager oOrdManager = new OrderManager();
           PDetails = oOrdManager.GetDetailInformation(ID);
           return PDetails.DetailInfo;       
        }
