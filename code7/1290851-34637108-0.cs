    object temp = (object)Agent.Port("PumpPressure1_01").Value.RawValue;
					
    UInt16[] PP1_01 = ((System.Collections.IEnumerable)temp).Cast<object>()
        .Select(x => Convert.ToUInt16(x))
		.ToArray();
					
	foreach(UInt16 x in PP1_01)
	{
		Agent.LogDebug("values: " + x.ToString());
	}
