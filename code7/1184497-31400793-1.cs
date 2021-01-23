      protected Task OnConnected(IRequest request, string connectionId){
        var context=new dbContext();
        context.Connections.Add(connectionId);
        context.Save();
      }
      protected Task OnDisconnected(IRequest request, string connectionId){        
        var context=new dbContext();
        var id=context.Connections.FirstOrDefault(e=>e.connectionId==connectionId);
        context.Connections.Remove(id);
        context.Save();
      } 
