    public class MyModel {
    
        public string AorB { get; set; }
    
        [RequiredIf("AorB == 'B'")]
        public string Foo { get; set; }
    
        [RequiredIf("AorB == 'B'")]
        public int? Bar { get; set; }
    }
