    public class SomeClass : SomeBaseClass
    {
        [Required]
        public string Foo { get; set; }
        public string Bar { get; set; }
    
        public override void DoSnapshot()
        {
            var properties = this.GetType().GetProperties();
            foreach (var property in properties)
            {
                var isRequired = property.GetCustomAttributes(typeof (RequiredAttribute), false).Length > 0;
                if (isRequired)
                {
                    // Something
                }
                else
                {
                    // SomethingElse
                }
            }
        }
    }
