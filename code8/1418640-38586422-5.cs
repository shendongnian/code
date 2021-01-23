    public class ConnService: IConnService
    {
        public bool IsConnected()        
       {
            return connectionStatus; //I don't understand if it is a static variable, sorry
        }
    }
