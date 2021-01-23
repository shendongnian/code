    public class Program
    {
    
        void Main()
        {
            var item1 = Item1ManagerAdapter.Get(1, 1);
            Item1ManagerAdapter.Save(item1);
            var item1Deleted = Item1ManagerAdapter.Delete(1, 1);
            var item1s = Item1ManagerAdapter.List(1);
            var item2 = Item2ManagerAdapter.Get(2, 2);
            Item2ManagerAdapter.Save(item2);
            var item2Deleted = Item2ManagerAdapter.Delete(2, 2);
            var item2s = Item2ManagerAdapter.List(2);
        }
    
    }
