    public class Service
    {
        private readonly IRepeater repeater;
        public Service(IRepeater repeater)
        {
            this.repeater = repeater;
        }
        public void Foo(string str, Action<string> action)
        {
            repeater.Each(str, action);
        }
    }
    public class ActionImplement
    {
        public virtual void Action(string str)
        {
            Console.Write(str);
        }
    }
    public interface IRepeater
    {
        void Each(string path, Action<string> action);
    }
