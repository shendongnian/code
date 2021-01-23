        private static void Main(string[] args)
        {
            var blueHandler = new Action<string, string>((x, y) => { });
            var redHandler = new Action<int, int>((x, y) => { Console.WriteLine(x);});
            
            var redStr = "Red";
            var blueStr = "Blue";
            var colorSelector = new Dictionary<string, Invoker>();
            var a = 10;
            var b = 20;
            colorSelector.Add(redStr, new Invoker(redHandler, a, b));
            colorSelector.Add(blueStr, new Invoker(blueHandler, a, b));
            colorSelector["Red"].Invoke();
        }
        public class Invoker
        {
            private Delegate _handler;
            public object[] _param;
            public Invoker(Delegate handler, params object[] param)
            {
                _param = param;
                _handler = handler;
            }
            public void Invoke()
            {
                _handler.DynamicInvoke(_param);
            }
        }
