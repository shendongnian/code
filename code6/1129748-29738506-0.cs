    public class MyObject
    {
        public void RemoveFromList(List<MyObject> list)
        {
            if (list == null)
                return;
            list.Remove(this);
        }
    }
