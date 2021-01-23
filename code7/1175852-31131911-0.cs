    public class FooProcessor
    {
        private readonly Color _color1;
        private readonly Color _color2;
        public FooProcessor(Color color1, Color color2)
        {
            _color1 = color1;
            _color2 = color2;
        }
        public Task ProcessAsync()
        {
            return Task.Run((Action) Process);
        }
        private void Process()
        {
            //add your logic here
        }
    }
