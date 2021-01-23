    abstract class AbstractClass{
       
       protected String socket;
       
       public AbstractClass(String socket){
          this.socket = socket;
       }
       public virtual void SendCommand(String cmd){
         //dostuff
       }
    }
    class A : AbstractClass{
      public A(String socket):base(socket){
      }
      //you can ovverride the virtual method if need be. 
    }
     
