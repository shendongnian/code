    abstract class Person
    {
        public abstract void LoadName(string name);
        public abstract void LoadName(int id);
    }
    
    class Soldier : Person
    {
        string soldierName;
        int ID;
    
        public override void LoadName(string name)
        {
            soldierName = name;
        }
    
        public override void LoadName(int id)
        {
            ID = id;
        }
    }
    
    class PersonManager
    {
        public void LoadNames(Person[] person, string[] names, int[] id)
        {
            for (int i = 0; i < person.Length; i++)
            {
                person[i].LoadName(names[i]);
                person[i].LoadName(id[i]);
            }
        }
    }
