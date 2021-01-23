    public enum State : byte
    {
        zero = 0,
        one = 1,
        two = 2
    }
    
    public class Neighborhood
    {
        public Neighborhood(State left, State center, State right)
        {
            this.Left = left;
            this.Center = center;
            this.Right = right;
        }
    
        public State Left { get; private set; }
    
        public State Center { get; private set; }
    
        public State Right { get; private set; }
    }
