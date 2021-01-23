    public class Message
    {
        public int id { get; set; }
        //a lot of properties here
        public virtual void print()
        {
            Console.WriteLine("id is " + id);
    
            //a lot of write lines here
        }
    }
    
    public class Comment : Message
    {
        public int parent_id { get; set; }
    
        public override void print()
        {
            Console.WriteLine("Parent Id: {0}", parent_id); //print the parent id
            base.print(); //now tell the base class Message to execute print... 
        }
    }
    
    public class Message2 : Message
    {
    
        public override void print()
        {
            Console.WriteLine("I am message two"); //print the parent id
            //note no base.print() so wont execute Message.print()
        }
    }
    
    
    public abstract class AbstractMessage
    {
        public int id { get; set; }
        public abstract void print(); //<-- note abstract therefore the derrived classes MUST implement the print() method
    }
    
    public class Message3 : AbstractMessage
    {
        public override void print() //<--- must be implemented
        {
            Console.WriteLine("Iam am message 3");
        }
    }
