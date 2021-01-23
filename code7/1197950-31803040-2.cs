	using System;
	using System.Web;
	using Microsoft.AspNet.SignalR;
	using System.Web.Script.Serialization;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	public class ConsultasHub : Hub {
		public override Task OnConnected() {
			//breakpoint here
			//some code
			//[...]
			return base.OnConnected();
		}
		public void SendMessage( string message ) {
			Clients.All.message(message);
		}
	}	
	
