    class Program
    {
        public class Updater
        {
            public void AddUpdateListeners(object[] listeners)
            {
                Func<object, MethodInfo> getUpdateMethod = l =>
                    l.GetType()
                        .GetMethod("Update", BindingFlags.Instance | BindingFlags.Public, null, new Type[0], null);
                listeners
                    .Select(listener => new { listener, update = getUpdateMethod(listener) })
                    .Where(l => l.update != null)
                    .Select(l => Delegate.CreateDelegate(typeof(UpdateDelegate), l.listener, l.update))
                    .OfType<UpdateDelegate>()
                    .ToList()
                    .ForEach(d => this.updateDel += d);
            }
            public void PublishCallbacks()
            {
                var handler = this.updateDel;
                if (handler != null)
                {
                    handler();
                }
            }
            private delegate void UpdateDelegate();
            private UpdateDelegate updateDel;
        }
        static void Main(string[] args)
        {
            var updater = new Updater();
            updater.AddUpdateListeners(new object[] { new A(), new B(), });
            updater.PublishCallbacks();
        }
        public class A
        {
            public void Update()
            {
                Console.WriteLine("A updated");
            }
        }
        public class B
        {
            public void Update()
            {
                Console.WriteLine("B updated");
            }
        }
    }
