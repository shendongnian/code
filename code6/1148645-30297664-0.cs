    string valueToCompare = "Value to match";
    Dictionary<string, string> dict = new Dictionary<string, string> 
                                      {
                                        {"Key 1", "A value"}, 
                                        {"Key 2", "Another value"}
                                      };
    bool found= dict.Values
                    .Any(value 
                         => 
                         value.Equals(valueToCompare,
                                      StringComparison.CurrentCultureIgnoreCase)
                        );
