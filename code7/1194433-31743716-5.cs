    public interface IProcessor
    {
        void Process(Model model);
        int Order();
    }
    public class P1 : IProcessor
    {
        public void Process(Model model)
        {
        }
        public int Order()
        {
            return 1;
        }
    }
    public class P2 : IProcessor
    {
        public void Process(Model model)
        {
        }
        public int Order()
        {
            return 2;
        }
    }
    public class P3 : IProcessor
    {
        public void Process(Model model)
        {
        }
        public int Order()
        {
            return 2;
        }
    }
    public class P4 : IProcessor
    {
        public void Process(Model model)
        {
        }
        public int Order()
        {
            return 3;
        }
    }
