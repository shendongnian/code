        abstract class Person
        {
            public abstract void LoadName(string name, int id);
        }
        class Soldier : Person
        {
            public string soldierName { get; set; }
            public int ID { get; set; }
            public override void LoadName(string name, int id)
            {
                soldierName = name;
                ID = id;
            }
        }
        class PersonManager
        {
            public void LoadNames(Person[] person, string[] names, int[] id)
            {
                for (int i = 0; i < p.Length; i++)
                {
                    if (person[i] is Soldier)
                    {
                        person[i].LoadName(names[i], id[i]); 
                    }
                }
            }
        }
    ​
