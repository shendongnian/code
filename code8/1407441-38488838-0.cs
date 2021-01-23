        public class MyHub : Hub 
        { 
            public void Send(string ipaddress, string name) 
            { 
                Clients.All.addMessage(ipaddress, name); 
            }
        }
