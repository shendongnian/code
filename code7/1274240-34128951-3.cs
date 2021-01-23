    var designSessionEntity = new DesignEntity();
    var jSerializer = new JavaScriptSerializer();
    
    designSessionEntity = /// Get Values via some method
    /// assign the design details with deserialized object
    designSessionEntity.DesignDetails = jSerializer.Deserialize<DesignDetailsObject>(designSessionEntity.designDetails);
    
    /// serialize it again
    var designJsonSession = jSerializer.Serialize(designSessionEntity); 
