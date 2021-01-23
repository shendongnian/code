    //test Case
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    namespace ApiController.Test
    {
	    [TestClass]
        public class DownloadIrregularJsonStringObjects
        {
            string ApiKey => "YourPersonalCensusKey";
		
		    /// <summary>
            /// You have to get your own ApiKey from the Census Website
            /// </summary>       
            [TestMethod]
            public void TestGetItem()
            {
            string url = $"http://api.census.gov/data/timeseries/healthins/sahie?get=NIC_PT,NAME,NUI_PT&for=county:*&in=state:*&time=2015&key={YourPersonalCensusKey}";
            string expected = "Autauga County, AL";
            IList<HealthData> actual = ApiController.DownloadIrregularJsonStringObjects.GetCensusHealthData(url);
            Assert.AreEqual(actual[0].NAME, expected);
        }
    }
}
    ///Actual Assembly
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    namespace ApiController
    {
       public  class DownloadIrregularJsonStringObjects
        {
            public static IList<HealthData> GetCensusHealthData(string url)
            {
                var json = GetData(url);
                var rawData = JsonConvert.DeserializeObject<string[][]>(json);
                var headerRow = rawData.First();
                var nic_pt_Index = Array.IndexOf(headerRow, "NIC_PT");
                var name_Index = Array.IndexOf(headerRow, "NAME");
                var nui_pt_Index = Array.IndexOf(headerRow, "NUI_PT");
                IList<HealthData> retVal = new List<HealthData>();
                foreach (var r in rawData.Skip(1))
                {
                    HealthData dataRow = new HealthData();
                    dataRow.NIC_PT = r[nic_pt_Index];
                    dataRow.NAME = r[name_Index];
                    dataRow.NUI_PT = r[nui_pt_Index];
                    retVal.Add(dataRow);                
                }
                return retVal;
            }
        private static string GetData(string url)
        {
            using (var w = new WebClient())
            {
                var jsonData = string.Empty;
                jsonData = w.DownloadString(url);
                return jsonData;
            }
        }
    }
    public class HealthData
    {
        public string NIC_PT { get; set; }
        public string NAME { get; set; }
        public string NUI_PT { get; set; }       
    }
