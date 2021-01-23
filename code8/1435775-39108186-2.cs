    public class Environment
    {
       public List<Location> Locations {set; get;}
       public Location CurrentLocation {get; set;}
       public Environment()
       {
           Locations = new List<Locations> {...} //set up Locations in a grid
           public Location Move(string direction)
           {
            //check to see if there is a location in the direction the user wants to move
            //if so, load the new Location into CurrentLocation. If not, throw an exception
           }
       }
    }
    public class Location
    {
       public List<Item> Items {set; get;}
       public List<Creature> Creatures {set; get;}
       public int X {get; set;} 
       public int Y {get; set;}
       public void OnLoaded()
       {
           //here is where you check if there are items, or creatures, etc, simply by counting the list...
       } 
    }
