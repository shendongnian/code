    class MappingParameters
    {
        public RetailerMappings RetailerMappings { get; set; }
        public int ManufacturerId { get; set; }
        public int RetailerId { get; set; }
        public bool SaveMapping { get; set; }
    }
    class RetailerMappings
    {
        public string Title { get; set; }
        public string ModelName { get; set; }
    }
---
    MappingParameters mapping = new MappingParameters();
    mapping.RetailerMappings = new RetailerMappings();
    mapping.RetailerMappings.Title = "unwanted HR186320 Philips VivaCollection juicer HR1863/20";
    mapping.RetailerMappings.ModelName = "HR186320 Philips VivaCollection juicer HR1863/20";
    mapping.ManufacturerId = 14;
    mapping.RetailerId = 652;
    mapping.SaveMapping = false;
