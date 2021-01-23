	using System;
	using System.Web;
	using Microsoft.AspNet.SignalR;
	namespace ProjectNamespace
	{
		public class ProgressHub : Hub
		{
			public Task Register(string processID)
			{
				return Groups.Add(Context.ConnectionId, processID);
			}
			
			public Task Unregister(string processID)
			{
				return Groups.Remove(Context.ConnectionId, processID);
			}
		}
	}
