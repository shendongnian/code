    namepsace Server{}
        public class YourHub : Hub {
            public void SomeHubMethod(string userName) { 
                //clientMethodToCall is a method in the WPF application that
                //will be called. Client needs to be registered to hub first.
                Clients.User(userName).clientMethodToCall("This is a test.");
            
               //One issue you may face is mapping client connections.
               //There are a couple different ways/methodologies to do this.
               //Just figure what will work best for you.
             }
        }
    }
    namespace Client{
        public class HubService{          
          
          public IHubProxy CreateHubProxy(){
              var hubConnection = new HubConnection("http://serverAddress:serverPort/");
              IHubProxy yourHubProxy = hubConnection.CreateHubProxy("YourHub");
              return yourHubProxy;
            }
        }
    
    }
