    class CustomDateTimeAxis : DateTimeAxis
    {
        List<object> _valueList = new List<object>();
        UnitValue prevBaseValue;
 
        protected override UnitValue GetPlotAreaCoordinate(object value, Range<IComparable> currentRange, double length)
        {
            _valueList.Add(value);
            UnitValue baseValue = base.GetPlotAreaCoordinate(value, currentRange, length);
            
            int valueCount = _valueList.Count((x) => x.Equals(value));
            if (valueCount == 2)                       
                return new UnitValue(baseValue.Value + 27, baseValue.Unit);
            prevBaseValue = baseValue;
            return baseValue;
            
        }
        protected override void Render(Size availableSize)
        {
            base.Render(availableSize);
            _valueList.Clear();
        }
    }
