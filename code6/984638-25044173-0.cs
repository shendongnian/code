    interface ICustomer {
        String name { get; }
    }
    public class OptionalCustomer : ICustomer {
         public OptionalCustomer (ICustomer value) {
              this.value = value;
         }
         public static OptionalCustomer Empty() {
              return new OptionalCustomer(null);
         }
         ICustomer value;
         public String name { get { 
             if (value == null ) {
                 return "No customer found";
             }
             return value.Name;
          }
        }
    }
