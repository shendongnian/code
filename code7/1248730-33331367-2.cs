        public class VokabelViewModelLateinDeutsch:ViewModelBase
    {
        public VokabelViewModelLateinDeutsch(Vokabel model)
        {
            Title = "VokabelViewModelLateinDeutsch";
        }
    }
    public class VokabelViewModelDeutschLatein : ViewModelBase
    {
        public VokabelViewModelDeutschLatein(Vokabel model)
        {
            Title = "VokabelViewModelDeutschLatein";
        }
    }
    public class Vokabel
    {
    }
    public class ViewModelBase:BaseObservableObject
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }
    }
