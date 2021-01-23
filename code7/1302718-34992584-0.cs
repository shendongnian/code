    public class AGuage
    {
        private float _value;
        public float Value
        {
            get;
            set
            {
                this._value = value;
                this.ValueChanged(this._value);
            }
        }
        public void ValueChanged(float newValue)
        {
            // Action to perform on value change
            // Update a text field after performing some calculations with a result.
        }
    }
