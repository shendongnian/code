    public class PeopleViewModel : NotifyUIBase
    {
        public ListCollectionView PeopleCollectionView {get; set;}
        private Person CurrentPerson
        {
            get { return PeopleCollectionView.CurrentItem as Person; }
            set
            {
                PeopleCollectionView.MoveCurrentTo(value);
                RaisePropertyChanged();
     
            }
        }
        public PeopleViewModel()
        {
            PeopleCollectionView = Application.Current.Resources["PeopleCollectionView"] as ListCollectionView;
            PeopleCollectionView.MoveCurrentToPosition(1);
        }
    }
