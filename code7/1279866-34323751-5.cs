    using System;
    using NCop.Composite.Framework;
    using NCop.Mixins.Framework;
    using NCop.Composite.Runtime;
    namespace NCop.Samples
    {
        [TransientComposite]
        [Mixins(typeof(EngineWindow), typeof(Testwindow))]
        public interface ICompositeWindow : IWindow, IEngineWindow
        {
        }
        public interface IWindow
        {
            void BeforeClose();
        }
        public interface IEngineWindow
        {
            void Show();
        }
        public class EngineWindow : IEngineWindow
        {
            public void Show() {
                Console.WriteLine("Showing window...");
            }
        }
        public class Testwindow : IWindow
        {
            public void BeforeClose() {
                Console.WriteLine("Closing...");
            }
        }
        class Program
        {
            static void Main(string[] args) {
                ICompositeWindow window = null;
                var container = new CompositeContainer();
                container.Configure();
                window = container.Resolve<ICompositeWindow>();
                window.Show();
                window.BeforeClose();
            }
        }
    }
    
