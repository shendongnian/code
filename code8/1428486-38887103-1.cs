    public class Comment : Message
    {
        public int parent_id {get;set;}
        //a lot of properties here
        public new void print()
        {
      	    base.print();
            // do additional work
        }
    }
