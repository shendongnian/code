    public class NavigationMenuItemCollection : CollectionBase  {
    
       public NavigationMenuItem this[ int index ]  {
          get  {
             return( (NavigationMenuItem) List[index] );
          }
          set  {
             List[index] = value;
          }
       }
       ...
