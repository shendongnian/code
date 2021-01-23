    class Program
    {
        static void Main(string[] args)
        {
            var account = new ExternalAccount() { Name = "Someone" };
            string json = JsonConvert.SerializeObject(account);
            string base64EncodedExternalAccount = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            byte[] byteArray = Convert.FromBase64String(base64EncodedExternalAccount);
    
            string jsonBack = Encoding.UTF8.GetString(byteArray);
            var accountBack = JsonConvert.DeserializeObject<ExternalAccount>(jsonBack);
            Console.WriteLine(accountBack.Name);
            Console.ReadLine();
        }
    }
    
    [Serializable]
    public class ExternalAccount
    {
        public string Name { get; set; }
    }
