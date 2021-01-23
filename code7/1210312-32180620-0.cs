    public Address(Guid? id,BuildingType type)
    {
     switch(type)
     {
      case BuildingType.House:
                       HouseId=id;
                       break; 
      case BuildingType.Flat:
                       FlatId=id;
                       break;
      case BuildingType.SomeOtherBuildingType:
                       SomeOtherBuildingTypeId =id;
                       break;
      default:
            break;
     }
    }
