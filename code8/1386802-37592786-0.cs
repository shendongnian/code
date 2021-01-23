    public partial class PingThings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        [WebMethod]
        public static string GetPing(string ipAddress)
        {
            Ping PingSender = new Ping();
            PingOptions PingOpt = new PingOptions();
            StringBuilder sb = new StringBuilder();
            PingReply reply = PingSender.Send(ipAddress);
            var ttl = reply.Options.Ttl;
            var rt = reply.RoundtripTime;
            sb.Append(Environment.NewLine + reply.Address + "\t" + ttl + "\t" + rt);
            return sb.ToString();
        }
    }
