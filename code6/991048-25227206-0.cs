    class CSVFileDefinitionFinal
    {
      private int _farmId;
    
      public int? FARM_ID 
      { 
        get { return _farmId }; 
        set { _farmId = value==null?-10:value; }
      }
    }
