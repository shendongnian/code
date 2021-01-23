    [DataContract]
    public class Unit
    {
        public static readonly Unit USFeet = new Unit("US Feet", 1);
        public static readonly Unit Meters = new Unit("Meters", 0.3048006096);
        private static Dictionary<string, Unit> _unitList;
        public static readonly Dictionary<string, Unit> UnitList = _unitList ?? (_unitList = new Dictionary<string, Unit>());
        [DataMember] private readonly double _conversionConstant;
        [DataMember] private readonly string _name;
        private Unit(string name, double conversionConstant)
        {
            _name = name;
            _conversionConstant = conversionConstant;
            UnitList.Add(name, this);
        }
    }
