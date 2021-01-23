        abstract class Person
        {
            public abstract void LoadName(string name);
        }
        class Soldier : Person
        {
            public string soldierName { get; set; }
            public int ID { get; set; }
            public override void LoadName(string name)
            {
                soldierName = name;
            }
            public void LoadName(int id)
            {
                ID = id;
            }
        }
        class PersonManager
        {
            public void LoadNames(Person[] person, string[] names, int[] id)
            {
                for (int i = 0; i < p.Length; i++)
                {
                    person[i].LoadName(names[i]);
                    if (person[i] is Soldier)
                    {
                        Person newPerson = new Soldier() { soldierName = names[i], ID = id[i] }; 
                    }
                }
            }
        }
    ​
