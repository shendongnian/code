    public class ModelA
    {
        public int Id
        {
            //Property uses INotifyPropertyChanged
        }
    }
    public class ModelB
    {
        public ModelA The_A
        {
            //Property uses INotifyPropertyChanged
        }
        public IEnumerable<ModelA> The_A_List
        {
            //Property uses INotifyPropertyChanged
        }
    }
    public class ViewModel
    {
        public ViewModel()
        {
            //Load lists
            foreach (var b in ModelBList)
            {
                b.The_A_List = ModelAList;
            }
        }
        public IEnumerable<ModelA> ModelAList
        {
            //Property uses INotifyPropertyChanged
        }
        public IEnumerable<ModelB> ModelBList
        {
            //Property uses INotifyPropertyChanged
        }
    }
