    class BaseCore<Configuration_type,Equipmentmanager_type>  
                   where Configuration_type : IConfiguration, new() 
                   where Equipmentmanager_type : IEquipmentmanager, new()
    {
       public Configuration_type Configuration {get;};
       public Equipmentmanager_type Equipmentmanager {get;};
       BaseCore()
       {
          Configuration = new Configuration_type();
          Equipmentmanager   = new Equipmentmanager_type();
       }
    }
