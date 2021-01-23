    public abstract class Migration
    {
        // ...
        protected DateTime StartTime { get; private set; }
        public Migration()
        {
            this.StartTime = DateTime.Now;
            Console.WriteLine("Start {0} - TIME: {1:yyyy-MM-dd HH:mm:ss.fff}", this.GetType().Name, StartTime);
        }
      
        public void Up()
        {
            OverrideUp();
            Console.WriteLine("End(?) {0} - TIME: {1}", this.GetType().Name, DateTime.Now.Substracts(StartTime));
        }
        public void Down()
        {
            // ...
            OverrideDown();
        }
        protected abstract void OverrideUp();
        protected abstract void OverrideDown();
    }
