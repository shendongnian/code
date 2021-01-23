    static class Program
    {
        static void Main(string[] args)
        {
            var lst = new ListOfMachines();
            lst.Add(new MachineInfo { Head = "Sports", Item = "Porshe 911", Quantity = 100 });
            lst.Add(new MachineInfo { Head = "Sports", Item = "Porshe 912", Quantity = 200 });
            lst.Add(new MachineInfo { Head = "Luxury", Item = "BMW 3 Series", Quantity = 300 });
            lst.Add(new MachineInfo { Head = "Small", Item = "Toyouta Corolla", Quantity = 400 });
            lst.Add(new MachineInfo { Head = "Small", Item = "Mitsubish Lancer", Quantity = 500 });
            lst.Add(new MachineInfo { Head = "Small", Item = "Mitsubish Lancer 2", Quantity = 600 });
            var json = lst.ToJson();
        }
    }
    public class ListOfMachines : List<MachineInfo>
    {
        public string ToJson()
        {
            var initialGroupBy = this.GroupBy(a => a.Head,
                                                t => new { item = t.Item,
                                                    quantity = t.Quantity}               
                ).ToDictionary(
                    k => k.Key,
                    s => s.Select(v => new {
                            item = v.item,
                            quantity = v.quantity
                    }));
            var javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string jsonString = javaScriptSerializer.Serialize(initialGroupBy);
            return jsonString;
        }
    }   
    public class MachineInfo
    {
        public string Head { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
    }
