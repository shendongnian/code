    public class NewClass 
    { 
        // [...]
        public void SomeThing()
        {
            // you move all your stuff to the new class
        }
        // [...]
    }
    
    [Obsolete("Is obsolete, please use NewClass instead")]
    public class OldClass 
    {
        private NewClass newClass = new NewClass();
    
        // [...]
        public void SomeThing()
        {
            // and delegate your old class calls to that.
            this.newClass.SomeThing();
        }
        // [...]
    }
