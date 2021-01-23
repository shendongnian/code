    double oneAsDouble = 1.0;
    int oneAsInteger = 1;
    Debug.Assert(oneAsDouble.Equals(oneAsInteger)); // Pass
    Debug.Assert(oneAsInteger.Equals(oneAsDouble)); // Pass
    Debug.Assert(Equals((object)oneAsDouble, (object)oneAsInteger)); // <-- Fails!
    Debug.Assert(oneAsDouble.Equals((object)OneAsInteger)); // <-- Fails!
    Debug.Assert(oneAsInteger.Equals((object)oneAsDouble)); // <-- Fails!
