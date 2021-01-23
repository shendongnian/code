    public class Gameplay {
       public static int count = 0;
    
       AClass aClass = new AClass( () => count );
    }
    
    public class AClass {
       public int count { get { return this.getCount(); } }
       private readonly Func<int> getCount;
       public AClass(Func<int> getCount) {
           this.getCount = getCount;
       }
    
       public void printCount() {
           Console.WriteLine(this.count.ToString());
       }
    }
