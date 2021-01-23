    namespace ASPMVC.Hubs
    {
       [HubName("CommunicationsHub")]
       public class CommunicationsHub : Hub
       {
          public void Send(string name, string message)
          {
            Debug.WriteLine("---------->"+name);
            //Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
           }
       }
     }
