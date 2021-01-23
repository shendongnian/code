    Make sure to add the constructor in the the class and declare list inside it. Other wise it would declared take null value which you won't be able to set for later.
    public class Item
    {
      public Item(){
    
        AvailableColours =new List<Color>();
    }
    
    }
