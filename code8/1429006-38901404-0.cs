    public class Gameplay {
       public static int count = 0;
    
       AClass aClass = new AClass();
    }
    
    public class AClass {
       public int count { get { return Gameplay.count; } set { Gameplay.count = value; } }
    
       public void printCount() {
           Console.WriteLine(this.count.ToString());
       }
    }
