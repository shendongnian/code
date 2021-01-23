        public class DeepStringReplacer
    {        
        public object Replace(object input, string oldValue, string newValue)
        {
            if (input is string)
            {
                return input.ToString().Replace(oldValue, newValue);
            }
            var fields = input.GetType().GetProperties();
            foreach (var field in fields)
            {
                var fieldValue = field.GetValue(input);
                field.SetValue(input, Replace(fieldValue, oldValue, newValue));
            }
            return input;
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ClientAddress Address { get; set; }
    }
    public class ClientAddress
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }    
    }
