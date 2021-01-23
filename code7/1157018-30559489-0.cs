     private List<Socket> _handlers = new List<Socket>();
     public static void AcceptCallback(IAsyncResult ar)
     {   
         Socket handler = listener.EndAccept(ar);    
         var state = new StateObject {WorkSocket = handler};
         handlers.Add(handler);
         handler.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0,   ReadCallback, state);
     }
