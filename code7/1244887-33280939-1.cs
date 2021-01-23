    public class Something
    {
        private int number = 10;
        public void Remove([MyRange(1, "number")] int remove)
        {
            number -= remove;
        }
        public void Add(int add)
        {
            number += add;
        }
    }
