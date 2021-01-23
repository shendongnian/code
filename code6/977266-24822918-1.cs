    DoNothing(42, integer.SByte); // Converts SByte to Int32
    DoNothing(42, integer.Byte); // Converts Byte to Int32
    DoNothing(42, integer.Int16); // Converts Int16 to Int32
    DoNothing(42, integer.Int32); // Already the same
    DoNothing(42, integer.Int64); // Converts Int32 to Int64
    DoNothing(42, integer.UInt16); // Converts UInt16 to Int32
    DoNothing(42, integer.UInt32); // Error - no implicit conversion
    DoNothing(42, integer.UInt64); // Error - no implicit conversion
    DoNothing((UInt32)42, integer.UInt32); // Explicitly converted to UInt32
    DoNothing((UInt64)42, integer.UInt64); // Explicitly converted to UInt64
