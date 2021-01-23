    class Program
    {
        static void Main(string[] args)
        {
            List<String> ids = new List<String>();
            String json ="{\"multicast_id\": \"xxxxx\",\"success\": 7,\"failure\": 0,\"canonical_ids\": 2,\"results\": [{\"message_id\": \"0:xxx%xxxxx\"}, {\"message_id\": \"0:xxx%xxxxx\"}, {\"registration_id\": \"456\",\"message_id\": \"0:xxx%xxxxx\"}, {\"message_id\": \"0:xxx%xxxxx\"}, {\"message_id\": \"0:xxx%xxxxx\"}, {\"registration_id\": \"123\",\"message_id\": \"0:xxx%xxxxx\"}, {\"message_id\": \"0:xxx%xxxxx\"}]}";
            RootObject decryptedMessage = new JavaScriptSerializer().Deserialize<RootObject>(json);
            int position = 0;
            Dictionary<int, String> canonicalIdsAndIndexes = new Dictionary<int, string>();
            foreach (var item in decryptedMessage.results)
            {
                if (item.registration_id != null)
                {
                    canonicalIdsAndIndexes.Add(position, item.registration_id);
                    Console.WriteLine("message id: {0}, registrationid: {1}", item.message_id, item.registration_id);
                }
                position++;
            }
            Console.ReadLine();
        }
    }
    public class Result
    {
        public string message_id { get; set; }
        public string registration_id { get; set; }
    }
    public class RootObject
    {
        public string multicast_id { get; set; }
        public int success { get; set; }
        public int failure { get; set; }
        public int canonical_ids { get; set; }
        public List<Result> results { get; set; }
    }
