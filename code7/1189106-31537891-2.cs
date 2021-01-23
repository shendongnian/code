    using System.Net;
    using Newtonsoft.Json;  
    class Program
    {
        static void Main(string[] args)
        {
            ReportDirections reportDirections = new ReportDirections();
            reportDirections.selected = "inbound";
            Times Times = new Times();
            Times.dateRange = "Last5Minutes";
            Filters Filters = new Filters();
            Filters.sdfDips_0 = "in_AC10033A_AC10033A-410";
            DataGranularity DataGranularity = new DataGranularity();
            DataGranularity.selected = "auto";
            ReportDetails ReportDetails = new ReportDetails();
            ReportDetails.reportTypeLang = "conversations";
            ReportDetails.reportDirections = reportDirections;
            ReportDetails.times = Times;
            ReportDetails.filters = Filters;
            ReportDetails.dataGranularity = DataGranularity;
            //
            QueryLimit QueryLimit = new QueryLimit();
            QueryLimit.offset = 0;
            QueryLimit.max_num_rows = 1;
            QueryLimit2 QueryLimit2 = new QueryLimit2();
            QueryLimit2.offset = 0;
            QueryLimit2.max_num_rows = 1;
            Table Table = new Table();
            Table.query_limit = QueryLimit;
            Table2 Table2 = new Table2();
            Table2.query_limit = QueryLimit2;
            Inbound Inbound = new Inbound();
            Inbound.table = Table;
            Outbound Outbound = new Outbound();
            Outbound.table = Table2;
            DataINeed DataINeed = new DataINeed();
            DataINeed.inbound = Inbound;
            DataINeed.outbound = Outbound;
            WebClient _webClient = new WebClient();
            _webClient.Headers.Add("Content-Type", "application/json");
            string data_requested = HttpUtility.UrlEncode(JsonConvert.SerializeObject(DataINeed));
            string rpt_json = HttpUtility.UrlEncode(JsonConvert.SerializeObject(ReportDetails));
            string data = "action=get&rm=report_api&data_requested=" + data_requested + "&rpt_json="+rpt_json;
            
            string address = "http://server/fcgi/scrut_fcgi.fcgi";
            var responseText = Encoding.Default.GetString(_webClient.UploadData(address, "POST", Encoding.Default.GetBytes(data)));
            Console.WriteLine(responseText);
        }
    }
    public class tw
    {
        public string rm { get; set; }
        public string action { get; set; }
        public string rpt_json { get; set; }
        public string data_requested { get; set; }
    }
    public class DataINeed
    {
        public Inbound inbound { get; set; }
        public Outbound outbound { get; set; }
    }
    public class Inbound
    {
        public Table table { get; set; }
    }
    public class Outbound
    {
        public Table2 table { get; set; }
    }
    public class Table
    {
        public QueryLimit query_limit { get; set; }
    }
    public class Table2
    {
        public QueryLimit2 query_limit { get; set; }
    }
    public class QueryLimit
    {
        public int offset { get; set; }
        public int max_num_rows { get; set; }
    }
    public class QueryLimit2
    {
        public int offset { get; set; }
        public int max_num_rows { get; set; }
    }
    public class ReportDetails
    {
        public string reportTypeLang { get; set; }
        public ReportDirections reportDirections { get; set; }
        public Times times { get; set; }
        public Filters filters { get; set; }
        public DataGranularity dataGranularity { get; set; }
    }
    public class ReportDirections
    {
        public string selected { get; set; }
    }
    public class Times
    {
        public string dateRange { get; set; }
    }
    public class Filters
    {
        public string sdfDips_0 { get; set; }
    }
    public class DataGranularity
    {
        public string selected { get; set; }
    }
    public class bob
    {
    }   
