    [Serializable] // don't forget this! It will mark your class so you can serialize it.
    public class BindingClass // p.s.: give this a better name!
    {
        public string Text { get; set; } // Bind whit a control of your tab control.
        public float Number { get; set; }
        public string ImageLocation { get; set; } // used for the image
        public IEnumerable<object> ListOfString { get; set; } // used for a list
    }
