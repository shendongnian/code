    public class Player2 {
       public Player1 Parent {private set;get}
       
       public Player2(Player1 parent) {
          this.Parent = parent;
       }
    
       public void MyMethod() {
           Parent.CustomMethodCall();
       }
    }
