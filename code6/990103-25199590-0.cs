    public class MyVM
    {
        private readonly IReactiveList data;
        //bind grid to this
        public ListCollectionView DataCollectionView { get; private set; }
        public MyVM(IReactiveList data)
        {
            this.data = data;
            this.DataCollectionView = new ListCollectionView(this.data);
            this.DataCollectionView.Filter = FilterData;
        }
        private bool FilterData(object o)
        {    
            //filter your data how ever you want in here. 
        }
    }
