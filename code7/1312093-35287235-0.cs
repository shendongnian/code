     public class myListContainer
    {
        public MyItem this[int i]
        {
            get
            {
                return MyHost.GetItemFromID(i);
            }
        }
    }
