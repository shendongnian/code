    public class AGauge {
        // You can either set the Value this way
        public float Value {
            get {return this.Value;}
            set 
            {
                 // (1)
                 // set "Value"
                 this.Value = value;
                 // raise event for value changed
                 OnValueChanged(null);
            }
        }
    
        // create an event for the value change
        // this is extra classy, as you can edit the event right
        // from the property window for the control in visual studio
        [Category("Action")]
        [Description("Fires when the value is changed")]
        public event EventHandler ValueChanged;
        protected virtual void OnValueChanged(EventArgs e)
        {
            // (2)
            // Raise the event
            if (ValueChanged != null)
                ValueChanged(this,e);
        }
    }
    public Form1 : Form {
        // In form, make your control and add subscriber to event 
        AGauge ag = new AGauge();
        // (3)
        ag.ValueChanged += UpdateTextBox;
        // (4)
        public void UpdateTextBox(object sender, EventArgs e) 
        {
            // update the textbox here
            textbox.Text = ag.Value;
        }
    }
