        public static ConcurrentDictionary<String, String> UsersOnline = new ConcurrentDictionary<String, String>();
        public override System.Threading.Tasks.Task OnConnected()
        {
            UsersOnline.TryAdd(Context.ConnectionId, Context.User.Identity.GetUserId());
            return base.OnConnected();
        }
