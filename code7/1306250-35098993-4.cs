    public class ValuesController : ApiController 
    {
        public IEnumerable<string> Get()
        {
            // your string concat
            string img = "sadadsasdsa";
            string actual = string.Format(
                                   CultureInfo.InvariantCulture,
                                   "<image src=\"data:img/jpg;base64,{0}\"/>",
                                   img);
            // DEBUG ONLY - for simplicity use ASCII encoding
            Encoding enc = Encoding.ASCII;
            foreach (byte b in enc.GetBytes(actual))
            {
                // write bytes and characters
                Debug.WriteLine(b.ToString("X2") + " " + enc.GetString(new byte[] {b}));
            }
            return new string[] { actual };
        }
