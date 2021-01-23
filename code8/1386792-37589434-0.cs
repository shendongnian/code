    class House
    {
       int _numberOfBedrooms;
    
       public House()
       {
       }
    
       public House AddBedrooms(int numberOfBedRoomsToAdd)
       {
          House house = new House();
          
          house._numberOfBedrooms = _numberOfBedrooms + numberOfBedRoomsToAdd;
    
          return house;
       }
       //etc...
    }
