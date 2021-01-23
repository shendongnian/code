    public abstract class Base
    {
         public virtual void BeforeSave()
         {
         }
    }
    public class User : Base
    {
         public string Name { get; set; }
         public int Age { get; set; }      
         public override void BeforeSave()
         {
              // You can access your properties here
              if (this.Name.Trim() == "")
                  throw new Exception("Name is mandatory!")
         }
    }
    public class DBObject<T>
        where T: Base
    {
        public void Save()
        {
            T.BeforeSave();
        }
    }
