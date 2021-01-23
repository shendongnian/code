    using System;
    using static System.Console;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    
    namespace StackCollection
    {
        class Program
        {
            static void Main(string[] args)
            {
                Progress progress = new Progress();
    
                progress.Items.Push(new Item { PlanID = null, PlanName = "Plan A" });
    
                var jsonString = JsonConvert.SerializeObject(progress);
                var temp = JsonConvert.DeserializeObject<Progress>(jsonString);
    
                temp.Items.Push(new Item { PlanID = null, PlanName = "Plan B" });
    
                jsonString = JsonConvert.SerializeObject(temp);
                temp = JsonConvert.DeserializeObject<Progress>(jsonString);
    
                temp.Items.Push(new Item { PlanID = null, PlanName = "Plan C" });
    
                jsonString = JsonConvert.SerializeObject(temp);
                temp = JsonConvert.DeserializeObject<Progress>(jsonString);
    
                WriteLine(temp.Items.Peek().PlanName);
    
                ReadLine();
            }
        }
    
        class Progress
        {
            [JsonIgnore]
            public Stack<Item> Items { get; set; }
    
            public List<Item> ItemList { get; set; }
    
            [OnSerializing]
            internal void OnSerializing(StreamingContext context)
            {
                ItemList = Items?.ToList();
            }
    
            [OnDeserialized]
            internal void OnDeserialized(StreamingContext context)
            {
                ItemList?.Reverse();
                Items = new Stack<Item>(ItemList ?? Enumerable.Empty<Item>());
            }
    
            public Progress()
            {
                Items = new Stack<Item>();
            }
        }
    
        class Item
        {
            public string PlanID { get; set; }
    
            public string PlanName { get; set; }
        }
    }
