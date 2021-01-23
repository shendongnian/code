    [Serializable]
    public class Prices
    {
        public string Serialize()
        {
            lock (this)
            {
                // logic for serilization here
            }
        }
    }
