    public abstract class MyBaseClass
    {
        // TODO: Common methods here.
        // Inheriting classes must implement this.
        public abstract void GetDataTable();
    }
        
    public class A : MyBaseClass
    {
        public void GetDataTable()
        {
            // Specific implementation here.
        }
    }
    public class B : MyBaseClass
    {
        public void GetDataTable()
        {
            // Specific implementation here.
        }
    }
