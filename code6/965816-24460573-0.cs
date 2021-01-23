    public class MyModel
    {
        [DisplayFormat(DataFormatString = "{0:n0}" ,ApplyFormatInEditMode = true)]
        public decimal IntValue { get; set; }
        public decimal DecimalValue { get; set; }
    }
