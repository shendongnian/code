    public class Parent{
       public int MethodX(int x){
             return x++;
       }
    }
    
    public class Child : Parent{
       public new int MethodX(int x){
             return x+2;
       }
    }
