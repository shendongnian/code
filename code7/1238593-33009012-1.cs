            public string ItemType { get; set; }
            public Random Random;
            public List<string> ItemTypeList = new List<string> { "Weapon", "Armor" };
**...**
            public Items(int iD, int droprarity, Random random)
            {
                Random = random;
                ID = iD;
