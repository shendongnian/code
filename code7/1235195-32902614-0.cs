    public class MyClass {
        [MyValidation]
        public Tuple<string, string> PropValue { get; set; }
        public List<ValidationResult> TestValidation() {
            var validationContext = new ValidationContext(this, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(this, validationContext, results, validateAllProperties: true);
            return results;
        }
    }
    public class MyValidationAttribute : ValidationAttribute {
        public override bool IsValid(object value) {
            var propValue = value as Tuple<string, string>;
            if (propValue.Item1 == "Item") {
                var setPropValue = propValue.Item2;
                //Do you validation
            }
            return true;
        }
    }
   
    class Program {
        static void Main(string[] args) {
            MyClass instance = new MyClass();
            instance.PropValue = new Tuple<string, string>("Item", "Value");
            var result = instance.TestValidation();
        }
    }
