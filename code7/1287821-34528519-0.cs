    public abstract class BaseClientInitializer
      {
        private string[] keys;
        public BaseClientInitializer(string[] keys)
        {
          this.keys = keys;
        }
    public abstract void Insert(string data);
    public void Init()
    {
      foreach (string pk in keys)
      {
        var data = JObject.Parse(DBUtils.GetData(Constants.DBProcedures.GetProcedures.GetWorkerDetailsByPkid, pk))[
            Constants.ResponseJson.Data].ToString();
        this.Insert(data);
      }
    }   
      }
    }
    public class Clerks : BaseClientInitializer
      {
        private Client client;
        public Clerks(Client client) : base(client.ClerksPKS.Trim(','). Split(','))
        {
          this.client = client;
        }
    
        public override void Insert(string data)
        {
          client.addClerk(JsonConvert.DeserializeObject<Clerk[]>(data)[0]);
        }
      }
    private void initClerks(Client client)
    {
         var clerksInitializer = new ClerksInitializer(client);
        clerksInitializer.Init();
    }
