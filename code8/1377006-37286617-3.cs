    public class Tool
    {
        private List<Hammer> hammers;
    
        public Tool()
        {
            hammers = new List<Hammer>();
    
        }
    
        public void addNewHammer()
        {
            hammers.Add(new Hammer());
        }
    
        public void addNewHammer(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                hammers.Add(new Hammer());
            }
        }
    
        public void removeHammer(int index)
        {
            hammers.RemoveAt(index);
        }
    
        public void removeAllHammer()
        {
            hammers.Clear();
        }
    
        public int getRemainingNum(int index)
        {
            return hammers[index].getRemainingNum();
        }
    
        public Hammer getCurrentHammerInstance(int index)
        {
            return hammers[index];
        }
    
        public Hammer[] getAllHammerInstance()
        {
            return hammers.ToArray();
        }
    }
    
    public class Hammer
    {
        private int numRemaining = 0;
        public int getRemainingNum()
        {
            return numRemaining;
        }
    }
