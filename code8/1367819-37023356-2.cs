        public class RowModel:BaseGridMember
    {
        public RowModel(int numberOfCellsInRow)
        {
            CellModels = new ObservableCollection<CellModel>();
            for (int i = 0; i < numberOfCellsInRow; i++)
            {
                CellModels.Add(new CellModel{Position = (i+1).ToString()});
            }
        }
        public ObservableCollection<CellModel>  CellModels { get; set; }
    }
    public class CellModel:BaseGridMember
    {
        
    }
    public class BaseGridMember:BaseObservableObject
    {
        private string _position;
        public string Position
        {
            get { return _position; }
            set
            {
                _position = value;
                OnPropertyChanged();
            }
        }
    }
