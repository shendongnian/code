      public string MyProperty { get; } // is a read only property of my class
      switch (filter)
         {
             case MyProperty:  // wont compile this since it is read only
             break;
              // rest of statements in Switch
         }
