    interface IListInterface
    {
        List<int> List;
    }
    class Lists: IListInterface
    {
        public Lists()
        { 
            List = new List<int>();
        }
        public List<int> List
        {
             get;
        }
    }
    // Using the above
    public void AddToList(IListInterface lists, int a)
    {
        lists.List.Add(a);
    }
