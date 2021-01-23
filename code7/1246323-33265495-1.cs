        public class DataGridMainDataContext
    {
        public DataGridMainDataContext()
        {
            Collection = new ObservableCollection<UserData>(new List<UserData>
            {
                new UserData
                {
                    UName = "Greg",
                    IsActive = false,
                },
                new UserData
                {
                    UName = "Joe",
                    IsActive = false,
                },
                 new UserData
                {
                    UName = "Iv",
                    IsActive = false,
                }
            });
        }
        public ObservableCollection<UserData> Collection { get; set; }
    }
