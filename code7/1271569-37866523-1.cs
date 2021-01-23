    QueryStringBuilder.BuildQueryString(new
           {
             Age = 19,
             Name = "John&Doe",
             Values = new object[]
                      {
                        1,
                        2,
                        new Dictionary<string, string>()
                        {
                          { "key1", "value1" },
                          { "key2", "value2" },
                        }
                      },
           });
    // 0=1&1=2&2%5B0%5D=one&2%5B1%5D=two&2%5B2%5D=three&3%5Bkey1%5D=value1&3%5Bkey2%5D=value2
    QueryStringBuilder.BuildQueryString(new object[]
           {
             1,
             2,
             new object[] { "one", "two", "three" },
             new Dictionary<string, string>()
             {
               { "key1", "value1" },
               { "key2", "value2" },
             }
           }
      );
