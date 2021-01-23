     [Serializable]
     public class Item 
     { 
            public Item() { }
    
            public string Name { get; set; }
            public string Rarity { get; set; }
            public int Damage { get; set; }
            public int Amount { get; set; }
            public int Price { get; set; }
            public bool Equipable { get; set; }
            public bool Equiped { get; set; }
            public bool Usable { get; set; }
            public string Description { get; set; }
        }
