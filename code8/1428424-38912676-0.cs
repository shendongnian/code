    public class ProfileInformation
    {
        [JsonProperty("querying")]
        public string Querying { get; set; }
        List<Tps> _tpsList = null;
        [JsonIgnore]        
        public List<Tps> TpsList {
            get {
                if (_tpsList == null && _tpsDict != null) {
                    _tpsList = _tpsDict.Values.ToList();
                }                    
                return _tpsList; 
            }
            set { _tpsList = value; }
        }
        Dictionary<int, Tps> _tpsDict = null;
        [JsonProperty("tps")]
        public Dictionary<int, Tps> TpsDict { 
            get {
                if (_tpsDict == null && _tpsList != null) {
                    _tpsDict = _tpsList.ToDictionary(x => x.TpId);
                }
                return _tpsDict;
            }
            set { _tpsDict = value; }
        }
    }
