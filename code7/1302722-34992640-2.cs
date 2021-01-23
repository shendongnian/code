    public class AGauge {
        public float Value {get; set;}
    
        // create an event for the value change
        // this is extra classy, as you can edit the event right
        // from the property window for the control in visual studio
        [Category("Action")]
        [Description("Fires when the value is changed")]
        public event EventHandler ValueChanged;
        protected virtual void OnValueChanged(EventArgs e)
        {
            // Raise the event
            if (ValueChanged != null)
                ValueChanged(this,e);
        }
        private void WhereCalculationsAreMadeForNewValue() 
        {
            // Let the program know the value is updated
            this.Value = ???;
            OnValueChanged(null);
        }
    }
    public Form1 : Form {
        // In form, make your control and add subscriber to event 
        AGauge ag = new AGauge();
        ag.ValueChanged += UpdateTextBox;
        public void UpdateTextBox(object sender, EventArgs e) 
        {
            // update the textbox here
            textbox.Text = ag.Value;
        }
    }
