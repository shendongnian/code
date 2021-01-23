    public class RandomParameter : Parameter
    {
        protected override object Evaluate(HttpContext context, Control control)
        {
            // you can get to page or environment from here with 'context' and 'control' parameters
            return new Random(Environment.TickCount).Next(Min, Max);
        }
        [DefaultValue(1)]
        public int Min
        {
            get
            {
                object o = ViewState["Min"];
                return o is int ? (int)o : 1;
            }
            set
            {
                if (Min != value)
                {
                    ViewState["Min"] = value;
                    OnParameterChanged();
                }
            }
        }
        [DefaultValue(10)]
        public int Max
        {
            get
            {
                object o = ViewState["Max"];
                return o is int ? (int)o : 10;
            }
            set
            {
                if (Max != value)
                {
                    ViewState["Max"] = value;
                    OnParameterChanged();
                }
            }
        }
    }
