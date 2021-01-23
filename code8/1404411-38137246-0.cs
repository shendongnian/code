    public class MyHub : Hub 
    { 
        public void Send(string name, string message) 
        { 
            Clients.All.addMessage(name, message); 
        } 
        public override Task OnConnected() 
        { 
            //Use Application.Current.Dispatcher to access UI thread from outside the MainWindow class 
            Application.Current.Dispatcher.Invoke(() => 
                ((MainWindow)Application.Current.MainWindow).WriteToConsole( 
                    "Client connected: " + Context.ConnectionId)); 
     
            return base.OnConnected(); 
        } 
        public override Task OnDisconnected() 
        { 
            //Use Application.Current.Dispatcher to access UI thread from outside the MainWindow class 
            Application.Current.Dispatcher.Invoke(() =>             
                ((MainWindow)Application.Current.MainWindow).WriteToConsole( 
                    "Client disconnected: " + Context.ConnectionId)); 
     
            return base.OnDisconnected(); 
        } 
    }
