    message Class1 {
       optional string Field1 = 1;
       // the following represent sub-types; at most 1 should have a value
       optional Class2 Class2 = 2;
    }
    message Class2 {
       optional string Field2 = 1;
    }
