    class Model
    {
        //model's property. Instead of your list
        public ObservableCollection<string> ModelCol { get; set; }
    }
    class ViewModel
    {
        Model model;
        public ViewModel ()
	    {
            model = new Model();
	    }
        
        //view model property returning model property. If you want, you can do
        //the customization here.
        public ObservableCollection<string> ViewModelCol {
        get 
        {
            return model.ModelCol; 
        }
        set 
        {
            //return collection from your model.
            model.ModelCol = value; 
        }
    }
   
