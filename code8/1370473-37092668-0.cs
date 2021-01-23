    [System.Serializable]
    public class ServiceProps
    {
    }
    
    [System.Serializable]
    public class DrawingResource
    {
        public string resourceUrl;
        public ServiceProps serviceProps;
        public string resourceType;
    }
    
    [System.Serializable]
    public class DrawingUnit
    {
        public string drawingUnitId;
        public List<DrawingResource> drawingResources;
        public string drawingComponentId;
    }
    
    [System.Serializable]
    public class TemplateConfig
    {
        public bool isVertical;
    }
    
    [System.Serializable]
    public class DrawingModule
    {
        public string subjectTemplateId;
        public List<DrawingUnit> drawingUnits;
        public TemplateConfig templateConfig;
    }
    
    [System.Serializable]
    public class Data
    {
        public string projectId;
        public string sensorId;
        public int createTime;
        public int updateTimeStamp;
        public string recognPicUrl;
        public DrawingModule drawingModule;
        public string targetId;
    }
    
    [System.Serializable]
    public class PlayerInfo
    {
        public string status;
        public Data data;
    }
