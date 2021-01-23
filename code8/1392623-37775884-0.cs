    class RootObject
    {
        public Data Data { get; set; }
    }
    class Data
    {
        [JsonProperty("valve_maker")]
        public List<string> ValveMaker { get; set; }
        [JsonProperty("water_volume")]
        public List<string> WaterVolume { get; set; }
        
        [JsonProperty("cylinder_manufacturer")]
        public List<string> CylinderManufacturer { get; set; }
        
        [JsonProperty("qc_stamp")]
        public List<string> QCStamp { get; set; }
        
        [JsonProperty("reference_standard")]
        public List<string> ReferenceStandard { get; set; }
        
        [JsonProperty("production_licence")]
        public List<string> ProductionLicense { get; set; }
        
        [JsonProperty("valve_production_licence")]
        public List<string> ValveProductionLicense { get; set; }
        
        [JsonProperty("rate_of_residual_deformation")]
        public Dictionary<string, string> RateOfResidualDeformation { get; set; }
        
        [JsonProperty("material_number")]
        public Dictionary<string, string> MaterialNumber { get; set; }
        
        [JsonProperty("heat_treatment")]
        public Dictionary<string, string> HeatTreatment { get; set; }
        
        [JsonProperty("drawing_number")]
        public Dictionary<string, string> DrawingNumber { get; set; }
        
        [JsonProperty("cylinder_thickness")]
        public List<string> CylinderThickness { get; set; }
    }
