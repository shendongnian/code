    public class MainWindowViewModel 
    {
        ObservableCollection<Requirement> requirements;
        public MainWindowViewModel()
        {
            requirements = new ObservableCollection<Requirement>(Enumerable
                .Range(0, 10)
                .Select(i => new Requirement {Rank = 10 - i, Name = "Item " + i}));
            RequirementsSource = new ListCollectionView(requirements);
            var live = (ICollectionViewLiveShaping)RequirementsSource;
            live.IsLiveSorting = true;
            live.IsLiveFiltering = true;
            live.LiveSortingProperties.Add("Rank");
            RequirementsSource.SortDescriptions.Add(
                new SortDescription("Rank", ListSortDirection.Ascending)
            );
            ReorderCommand = new DelegateCommand(Reorder);
        }
        public ListCollectionView RequirementsSource { get; set; }
        public DelegateCommand ReorderCommand { get; private set; }
        private void Reorder()
        {
            for (int i = 0; i < requirements.Count - 1; i += 2)
            {
                var temp = requirements[i].Rank;
                requirements[i].Rank = requirements[i + 1].Rank;
                requirements[i + 1].Rank = temp;
            }
        }
    }
   <!-- -->
    public class Requirement : BindableBase
    {
        private double _rank;
        public double Rank
        {
            get { return _rank; }
            set { SetProperty(ref _rank, value); }
        }
        public string Name { get; set; }
    }
