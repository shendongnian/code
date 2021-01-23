    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace SharpConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Welcome to SharpConsole. Type in a command.");
    
                while (true)
                {
                    Console.Write("$ ");
                    string command = Console.ReadLine();
    
                    string command_main = command.Split(new char[] { ' ' }).First();
                    string[] arguments = command.Split(new char[] { ' ' }).Skip(1).ToArray();
                    if (lCommands.ContainsKey(command_main))
                    {
                        Action<string[]> function_to_execute = null;
                        lCommands.TryGetValue(command_main, out function_to_execute);
                        function_to_execute(arguments);
                    }
                    else
                        Console.WriteLine("Command '" + command_main + "' not found");
                }
            }
    
            private static Dictionary<string, Action<string[]>> lCommands = 
                new Dictionary<string, Action<string[]>>()
                {
                    { "help", HelpFunc },
                    { "cp" , CopyFunc }
                };
    
            private static void CopyFunc(string[] obj)
            {
                if (obj.Length != 2) return;
                Console.WriteLine("Copying " + obj[0] + " to " + obj[1]);
            }
    
            public static void HelpFunc(string[] args)
            {
                Console.WriteLine("===== SOME MEANINGFULL HELP ==== ");
            }
        }
    }
