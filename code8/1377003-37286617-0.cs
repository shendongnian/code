    class Tool
    {
        List<Hammer> hammers;
        public Tool()
        {
            hammers = new List<Hammer>();
        }
        public void addNewHammer()
        {
            hammers.Add(new Hammer());
        }
        public void removeHammer(int index)
        {
            hammers.RemoveAt(index);
        }
        public int getRemainingNum(int index)
        {
            return hammers[index].getRemainingNum();
        }
    }
    class Hammer
    {
        private int numRemaining = 0;
        public int getRemainingNum()
        {
            return numRemaining;
        }
    }
