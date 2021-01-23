    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    
    namespace StackOverflow38200633
    {
        class Program
        {
            static void Main(string[] args)
            {
                Collection<IControl> controls = new Collection<IControl>();
                controls.Add(ControlFactory.Create());
                controls.Add(ControlFactory.Create());
                controls.Add(ControlFactory.Create());
    
                ControlManager manager = new ControlManager(controls);
    
                Console.WriteLine("Enter method ID:");
                int methodID = Convert.ToInt32(Console.ReadLine());
    
                try
                {
                    switch(methodID)
                    {
                        case 0:
                            Console.WriteLine("Enter the time in long: ");
                            long time = Convert.ToInt64(Console.ReadLine());
                            manager.InvokeAllSetTime(time);
                            break;
                        case 1:
                            manager.InvokeAllNop();
                            break;
                        default:
                            Console.WriteLine("You entered wrong method ID or parameters");
                            break;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    
        public interface IControl
        {
            void SetTime(long time);
            void Nop();
        }
    
        public class ConcreteControl : IControl
        {
            public void SetTime(long time)
            {
                Console.WriteLine("inside Control.SetTime {0} ", time);
            }
            public void Nop()
            {
                Console.WriteLine("inside Control.Nop ");
            }
        }
    
        public class ControlManager
        {
            public void InvokeAllSetTime(long time)
            {
                foreach(IControl control in _controls) control.SetTime(time);
            }
            public void InvokeAllNop()
            {
                foreach(IControl control in _controls) control.Nop();
            }
            public ControlManager(Collection<IControl> controls)
            {
                _controls = controls;
            }
            public Collection<IControl> _controls { get; private set; }
        }
    
        public static class ControlFactory
        {
            public static IControl Create()
            {
                return new ConcreteControl();
            }
        }
    }
