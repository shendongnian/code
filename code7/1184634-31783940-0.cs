     [ComVisible(true)]
     [ClassInterface(ClassInterfaceType.AutoDispatch)]
     public class DomMouseMoveEventManager
     {
         public event DomMouseMoveEventHandler DomMouseMove;
         [DispId(0)]
         public void CallbackFunction(mshtml.IHTMLEventObj arg)
         {
             //Console.WriteLine(String.Format("[{0}, {1}]", arg.clientX, arg.clientY));
             OnDomMouseMove(arg.clientX, arg.clientY);
         }
         private void OnDomMouseMove(int clientX, int clientY)
         {
             if(DomMouseMove != null)
             {
                 var args = new DomMouseMoveEventArgs(clientX, clientY);
                 DomMouseMove(this, args);
             }
         }
     }
