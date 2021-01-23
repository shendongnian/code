       namespace fizzbuzz { // <- do not forget "{"
          // Not static! You (== your test) want to create instances
          public class FizzBuzz {  
            // create, passing int (exactly as test wants)
            public FizzBuzz(int value) {
              Value = value;
            }
        
            // ToString will want the value 
            public int Value {get; set;}
        
            // ToString to call in the test
            public override ToString() {
              if (Value % 5 == 0)  
                return "Buzz";
        
              return Value.ToString(); 
            }
          }
       }
