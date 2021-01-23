            public Bar(int value)
            {
                if (Enum.IsDefined(typeof(Foo), value))
                {
                    var enumValue = GetEnumValue(typeof(Foo), value);
                }
                else
                {
                    var enumValue = GetEnumValue(typeof(Foo), 1);
    
                    //or like this...
                    var enumValue1 = Enum.GetValues(typeof(Foo)).GetValue(0);
                }
            }
