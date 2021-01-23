    public class GameHub : Hub
    {
        public void testObject(Object MyInfo)
        {
            Clients.Caller.testObject(MyInfo);
        }
    }
