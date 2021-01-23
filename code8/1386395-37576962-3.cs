    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace BasicDataStorageApp
    {
        class Program
        {
            static Model _model;
            const int _totalInput = 10;
            const string _filename = @"C:\temp\DataEntry.txt";
    
            static void Main(string[] args)
            {
                _model = new Model();
                _model.Items = new Item[_totalInput];
    
                Console.WriteLine("This program is designed to take input and hold data for 10 items");
    
                int i = 0;
                while (i < _totalInput)
                {
                    int number = -1;
    
                    Console.WriteLine("\nEnter number: ");
                    string numberValue = Console.ReadLine();
    
                    if (Int32.TryParse(numberValue, out number))
                    {
                        _model.Items[i] = new Item(number, null);
    
                        Console.WriteLine("\nEnter description: ");
                        string descriptionValue = Console.ReadLine();
    
                        _model.Items[i].Description = descriptionValue;
    
                        i++;
                    }
                }
    
                _model.WriteItems(_filename, true);
    
                var itemStrings = _model.ReadItems(_filename);
                foreach (var s in itemStrings)
                {
                    Console.WriteLine(s);
                }
    
                Console.ReadLine();
            }
        }
    }
