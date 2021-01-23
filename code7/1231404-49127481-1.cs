    public class Protocols : WebTestPlugin
    {
        public override void PreRequest(object sender, PreRequestEventArgs e)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }
    }
