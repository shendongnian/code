    using System;
    using System.Reflection;
    namespace CommandExample
    {
        class Program
        {
            static void Main()
            {
                var cmdName = "Command1";
            
                // Create an instance of the command class using reflection
                Type type = Assembly.GetExecutingAssembly().GetType("CommandExample." + cmdName);
                if (type == null) { /* Cannot find command. Handle error */ }
                var cmd = Activator.CreateInstance(type) as ICommand;
                cmd.Exec();
            }
        }
        interface ICommand
        {
            void Exec();
        }
        class Command1 : ICommand
        {
            public void Exec()
            {
                Console.WriteLine("Executing Command1");
            }
        }
    }
