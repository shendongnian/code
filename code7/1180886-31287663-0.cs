    namespace TestMVVM
    {
        public class BuildingViewModel : ViewModelBase
        {
            private Building building;
            private ObservableCollection<Floor> _floors;
    
            public string strName
            {
                get { return building.strName; }
                set
                {
                    //building.strName = value;
                    if (String.IsNullOrEmpty(value)) 
                    {
                        AddError("strName", "Name cannot be empty.");
                        return;
                     }
                     building.strName = value;
                    OnPropertyChanged("strName");
                }
            }
    
            public ObservableCollection<Floor> floors
            {
                get
                {
                   return _floors;
                }
                set 
                {
                   _floors = value;
                }
            }
    
            public BuildingViewModel(Building b)
            {
                building = b;
            }
            public void AddNewFloor(Floor)
           {
              // valid your floor
              // floors.Add(floor);
            }
        }
    
