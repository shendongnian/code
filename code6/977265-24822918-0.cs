    DoNothing(42, integer.SByte); // Converts SByte to int
    DoNothing(42, integer.Byte); // Converts Byte to int
    DoNothing(42, integer.Int16); // Converts Int16 to int
    DoNothing(42, integer.Int32); // Already the same
    DoNothing(42, integer.Int64); // Converts int to Int64
    DoNothing(42, integer.UInt16); // Converts UInt16 to int
    DoNothing(42, integer.UInt32); // Error - no conversion
    DoNothing(42, integer.UInt64); // Error - no conversion
    DoNothing((UInt32)42, integer.UInt32); // Already the same UInt32
    DoNothing((UInt64)42, integer.UInt64); // Already the same UInt64
