    public object Read(object value, ProtoReader source)
    {
        Helpers.DebugAssert(value == null); // since replaces
        int wireValue = source.ReadInt32();
        if(map == null) {
            return WireToEnum(wireValue);
        }
        for(int i = 0 ; i < map.Length ; i++) {
            if(map[i].WireValue == wireValue) {
                return map[i].TypedValue;
            }
        }
        // ISSUE #422
        source.ThrowEnumException(ExpectedType, wireValue);
        return null; // to make compiler happy
    }
