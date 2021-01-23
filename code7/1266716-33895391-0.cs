    abstract class AbstractRoom 
    {
        public bool[] av;
    
        public bool availability()
        {
            // some logic
        }
    
        public bool availability(int room)
        {
            // some logic   
        }
    
        public int allocate()
        {
            // some logic
        }
    
        public void roomStatus()
        {
            // some logic
        }
    }
    class MyConcreteRoom1 : AbstractRoom
    {
    }
    
    class MyConcreteRoom2 : AbstractRoom
    {
    }
