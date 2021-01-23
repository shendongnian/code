    public partial class BusinessLayer  
    {
        private readonly Dictionary<string,IJDE8Dal> _JDE8dals;
    
        public BusinessLayer(Dictionary<string,JDEDalConfig> jdeConfigs)
        {
            foreach (var j in jdeConfigs)
            {
                _JDE8dals.Add(j.Key,new JDE8Dal(j.Value));
            }
        }
    }
