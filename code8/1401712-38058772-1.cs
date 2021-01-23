     public class Dog {
       public int TagNumber {get; private set}
       ...
       public decimal Price {get; private set}
       ...
     } 
     var data = File
       .ReadLines(location) 
       .Select(line => Dog.Parse(line));
     ...
     myComboBox.Items.AddRange(data
       .Where(dog => (dog.Breed == "Bulldog") &&
                     ((dog.Name == "Mary") || (dog.Name == "Cayne"))))
       .Select(dog => dog.ToString()));
 
