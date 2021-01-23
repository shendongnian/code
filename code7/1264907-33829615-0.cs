    public class Setting
    {
        public string Format
        { 
            get
            {
                return String.Format(this.Format, this.Colour);
            }
            set
            {
                Format = value;
            }
        }
 
        public string Colour { get; set; }
    }
    var setting = new Setting { Format = "The car is {0}", Colour = "black" };
