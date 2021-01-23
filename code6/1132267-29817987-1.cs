    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        public interface IMyType
        {
            string Text { get; }
            int Number { get; }
        }
        public class MyType<T> : IMyType where T : SomeOtherType
        {
            public MyType()
            {
                Text = "Hello World";
                Number = 999;
            } 
            public string Text { get; private set; }
            public int Number { get; private set; }
        }
        public abstract class SomeOtherType
        {
            public int Id { get; set; }
            public string Title { get; set; }
        }
        public class ConcreteType : SomeOtherType
        {
            public string Description { get; set; }
        }
        public interface IFaceThatAccessesIt
        {
            IList<Func<IMyType, bool>> GetList();
        }
        public class ClassThatAccessesIt<T> : IFaceThatAccessesIt where T : SomeOtherType
        {
            /// <summary>
            /// Generically typed inner list
            /// </summary>
            private readonly List<Func<MyType<T>, bool>> _innerList = new List<Func<MyType<T>, bool>>();
    
            /// <summary>
            /// Get list converted
            /// </summary>
            /// <returns></returns>
            public IList<Func<IMyType, bool>> GetList()
            {
                var output = _innerList.ConvertAll(func =>
                {
                    Func<IMyType, bool> outFunc = type => func.Invoke((MyType<T>)type);
                    return outFunc;
                });
                return output;
            }
    
            /// <summary>
            /// Add to list
            /// </summary>
            /// <param name="func"></param>
            public void AddToList(Func<MyType<T>, bool> func)
            {
                _innerList.Add(func);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                // get class / instance the uses said list
                var asClass = new ClassThatAccessesIt<ConcreteType>();
                var asInterface = (IFaceThatAccessesIt) asClass;
    
                // add into list (via class, not interface)
                asClass.AddToList(input => input.Number == 999);
                asClass.AddToList(input => input.Text == "Hello World");
    
                // get list from interface
                var listFromInterface = asInterface.GetList();
    
                // get function 1
                var func1 = listFromInterface.First();
    
                // invoke
                var inputInstance = new MyType<ConcreteType>();
                var result = func1.Invoke(inputInstance);
    
                // print
                Console.WriteLine("This result should be 'True'... {0}",result);
    
            }
        }
    }
