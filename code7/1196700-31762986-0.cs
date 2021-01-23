    public class ReminderHub : Hub
    {
    	public Dictionary<string,string> _conn = new Dictionary<string,string>();
        public void Store(string username, DateTime date)
        {
            // Store into the database
            // ....
            // ...
            // Store the realation between the connection and the username
            _conn.Add(username,Context.ConnectionId);
            
        }
        public void Notify(string username)
        {
            // notify method is defined in the client (js)
        	Clients.User(_conn[username]).notify(username);
        }
    } 
