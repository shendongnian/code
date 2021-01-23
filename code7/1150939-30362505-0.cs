        public override Task OnConnected()
        {
            Task task = new Task(() =>
                {
                    UserHandler.ConnectedIds.Add(Context.ConnectionId, UserHandler.ConnectedIds.Count + 1);
                    int amountOfConnections = UserHandler.ConnectedIds.Count;
                    var lastConnection = UserHandler.ConnectedIds.OrderBy(x => x.Value).LastOrDefault();
                    var allExceptLast = UserHandler.ConnectedIds.Take(amountOfConnections - 1).Select(x => x.Key).ToList();
                    if (amountOfConnections == 1)
                    {
                        Clients.Client(UserHandler.ConnectedIds.First().Key).hello("Send to only(also first) one");
                    }
                    else
                    {
                        Clients.Clients(allExceptLast).hello("Send to everyone except last");
                        Clients.Client(lastConnection.Key).hello("Send to only the last one");
                    }
                });
            task.ContinueWith(base.OnConnected());
            return task;
        }
