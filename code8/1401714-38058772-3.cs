     public class Dog {
       public int TagNumber {get; private set}
       ...
       public decimal Price {get; private set}
       ...
       public static Dog Parse(String value) {...}
       ...
       public override String ToString() {
         return String.Fromat("tag: {0}; price: {1}", TagNumber, Price);  
       }
     } 
     var data = File
       .ReadLines(location) 
       .Select(line => Dog.Parse(line));
     ...
     myComboBox.Items.AddRange(data
       .Where(dog => (dog.Breed == "Bulldog") &&
                     ((dog.Name == "Mary") || (dog.Name == "Cayne"))))
       .Select(dog => dog.ToString()));
 
