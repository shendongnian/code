    public class ViewModel
    {
        public object Property
        {
            get
            {
                return Model.Property;
            }
            set
            {
                 Model.Property = value;
                 methodToBeCalledWhenPropertyIsSet(); // Here you call your method directly
            }
        }
    }
