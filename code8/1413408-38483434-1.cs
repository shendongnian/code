    [WebMethod]
        public static string GetBarchartData(string word)
        {
        string sqlQuery = @"SELECT TOP 40 DateDescription, COUNT(DescriptionDemande) FROM cfao_DigiHelp_index.DigiHelpData WHERE DescriptionDemande like '%" + word + "%' GROUP BY DateDescription";
        DataTable DTGraph = DataBaseCacheDigitalHepDeskConnection.SqlDataTable(sqlQuery, "DIGIHELP_DB");
        List<GraphData> dataList = new List<GraphData>();
        foreach (DataRow dtrow in DTGraph.Rows)
        {
            GraphData graphData = new GraphData();
            graphData.value = Convert.ToString(dtrow[1].ToString());
            graphData.label = Convert.ToString(DateTime.Parse( dtrow[0].ToString()).ToShortDateString());
            dataList.Add(graphData);
        }
        var jsonSerializer = new JavaScriptSerializer();
        string data = jsonSerializer.Serialize(dataList);
        return data;
    }
    }
    public class GraphData
    {
        public string label { get; set; }
        public string value { get; set; }
    }
    
    public class GraphDataList
    {
        public List<GraphData> ListOfGraphData { get; set; }
    }
