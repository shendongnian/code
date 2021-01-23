    public class ViewModel
    {
        public Model Model{get;set;}
        public bool IsSelected{get;set;}
        public int Val1{get;set;}
        public string Val2{get;set;}
        public void Save()
        {
            //Copy ViewModel to Model and trigger Save Logic
        }
        public void Cancel() //allows undoing
        {
            //Copy Model to ViewModel
        }
    }
