    public class Base {
    
       public string thing = "Thing";
    
       public T GetAttribute<T> ( string _name ) {
          return (T)typeof(Base).GetField( _name ).GetValue (this, null);
       }   
    }
