    public class DeHavMenu
    {
        private string foodName;
        private double price;
        private bool isSelected;
    
        public bool IsSelected
        {
        	get { return isSelected; }
        	set
        	{
        		isSelected = value;
        		RaisePropetyyChanged(); // If XAML data-binding
        	}
        }
    
        public string FoodName
        {
            get {return foodName; }
    
            set {  foodName = value; }
        }
    
        public double Price
        {
            get {return price;}
    
            set {  price = value; }
        }
    
        public DeHavMenu(string f, double p)
        {
            this.foodName = f;
            this.price = p;
        }
    
       	public override string ToString()
    	{
    	    return (this.FoodName + " Price: £" + this.Price);
    	}
    }
