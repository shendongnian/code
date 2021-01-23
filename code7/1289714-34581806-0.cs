    using System;
    using System.Collections.Generic;
    namespace Example
    {
        class Program
        {
            static void Main(string[] args)
            {
                Commander C = new Commander();
                C.Subscribe((MyCommand i) => { Console.WriteLine(i.Value); });
                C.Subscribe((SquareMyCommand i) => { Console.WriteLine(i.Value); });
                C.Subscribe((SquareMyCommand i) => { Console.WriteLine("**" + i.Value + "**"); });
                C.Do(new MyCommand(2));//1 callback , Prints 2
                C.Do(new SquareMyCommand(3));//2 callbacks, Prints 9 , **9**
                Console.ReadLine();
            }
        }
        public class Commander
        {
            Dictionary<Type, List<Action<ICommand>>> dictionary = new Dictionary<Type, List<Action<ICommand>>>();
            public void Subscribe<T>(Action<T> callback) where T : ICommand
            {
                Type type = typeof(T);
                List<Action<ICommand>> subscribtions = null;
                dictionary.TryGetValue(type, out subscribtions);
                if (subscribtions == null)
                {
                    subscribtions = new List<Action<ICommand>>();
                    dictionary.Add(type, subscribtions);
                }
                subscribtions.Add(i => callback((T)i));
            }
            public void Do<T>(T t) where T : ICommand
            {
                foreach (var item in dictionary[t.GetType()])
                    item(t);
            }
        }
        public class MyCommand : ICommand
        {
            public MyCommand(int x) { Value = x; }
            public int Value { get; set; }
        }
        public class SquareMyCommand : ICommand
        {
            public SquareMyCommand(int x) { Value = x * x; }
            public int Value { get; set; }
        }
        public interface ICommand
        {
            int Value { get; set; }
        }
    }
