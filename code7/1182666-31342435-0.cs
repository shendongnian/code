    using System;
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    
    class Test
    {
        static void Main(string[] args)
        {
            var collection = new ObservableCollection<string>();
            ((INotifyPropertyChanged)collection).PropertyChanged += (sender, e) =>
            {
                Console.WriteLine($"  {e.PropertyName} changed");
            };
            
            Console.WriteLine("Adding");
            collection.Add("Item");
            Console.WriteLine("Adding");
            collection.Add("Other item");
            Console.WriteLine("Removing");
            collection.RemoveAt(0);
            Console.WriteLine("Changing");
            collection[0] = "Different";
        }
    }
