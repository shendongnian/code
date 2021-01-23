     public void DoSomething()
     {
        if (_sharedEnumVal == MyEnum.First) {
           DoPrettyThings();
        } else {
           DoUglyThings();
        }
     }
     public void UpdateValue(MyEnum newValue)
     {
         _sharedEnumVal = newValue;
     }
