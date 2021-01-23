    public class Class_A : ClassBase
    {
        private readonly string text;
        public Class_A(XmlNode settings, string text)
            : base(settings) // Which calls Init(settings) as per intro paragraph
        { 
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            this.text = text;           
        }
        protected override void Init(XmlNode settings)
        {
            // In here, text is still null... even though it can't be in any
            // other method.
        }
    }
