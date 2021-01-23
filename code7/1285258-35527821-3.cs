    public class Example
    {
        public int x { get; set; }
        public virtual bool ShouldSerializex()
        {
            return <your logic expression here>;
        }
    }
