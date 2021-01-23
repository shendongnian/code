    public class MyListBase<T> : List<T>
        where T: Server
    { 
        public BindingList<T> ToBindingList()
        {
            BindingList<T> myBindingList = new BindingList<T>();
            foreach (Repository item in this.ToList<T>())
                myBindingList.Add(item);
            return myBindingList;
        }   
    }
