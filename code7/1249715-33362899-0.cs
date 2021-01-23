    public class Client
    {
       private int clientId;
       // editable property => editable column
       public int ClientId { get { return clientId; } set {clientId = value;} }
   
       private string clientName;
       // readonly property => readonly column
       public string ClientName { get { return clientName; } }
       // ... same for the rest variables
    }
