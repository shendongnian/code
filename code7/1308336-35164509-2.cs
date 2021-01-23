    class Program
    {
        static void Main()
        {
            var test = new Test();
            var model = new Model();
            test.AddModel(model);
            var fetch = test.GetModel<FactoryItem>();
            Console.WriteLine(fetch == model 
                                  ? "It does in fact work..." 
                                  : "Uh, that was supposed to work?");
            Console.ReadLine();
        }
        public class Test
        {
            private readonly Dictionary<Type, object> _allModelsByType;
            public Test()
            {
                _allModelsByType = new Dictionary<Type, object>();
            }
            public void AddModel<T>(IModel<T> model) where T : IFactoryItem
            {
                _allModelsByType.Add(typeof(T), model);
            }
            public IModel<T> GetModel<T>() where T : IFactoryItem
            {
                var tmpType = typeof(T);
                return _allModelsByType.ContainsKey(tmpType)
                    ? _allModelsByType[tmpType] as IModel<T>
                    : null;
            }
        }
    }
    internal class FactoryItem : IFactoryItem { }
    internal class Model : IModel<FactoryItem>
    {
        public FactoryItem Value { get; set; }
    }
    internal interface IFactoryItem { }
    internal interface IModel<T> where T : IFactoryItem
    {
        T Value { get; set; }
    }
