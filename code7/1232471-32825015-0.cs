    public class B<T>: A<T> where T:TreeView
    {
        protected override void Method ()
        {
            _t.CallSomeTreeViewMethod (); // ok!
        }
    
        public B (T tree): base (tree)
        {
    
        }
    } 
