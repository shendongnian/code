    public class AGuage
    {
        private float _value;
        // create object of Form1 for reference
        private Form1 form1;
        // pass reference to form1 through constructor
        public AGauge(Form1 form1)
        {
            // assign
            this.form1 = form1;
        }
        public float Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
                this.ValueChanged(this._value);
            }
        }
        public void ValueChanged(float newValue)
        {
            // use the form1 reference
            this.form1.Pressure_Raw.Text = "Working";
        }
    }
