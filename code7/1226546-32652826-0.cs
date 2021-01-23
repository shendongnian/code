    public interface ILayer
    {
        void pop_in();
    }
    public GameLayer : ILayer
    {
        public void pop_in()
        {
            // GameLayer-specific implementation
        }
    }
