       public BaseMaskedTextBoxDate2()
        {
            this.LocationChanged += new EventHandler(Setup);
        }
        //*************************************************************************************************
        private void Setup(object sender, EventArgs e)
        {
            MaskedTextBox maskedBox = (MaskedTextBox)sender;
            maskedBox.BackColor = Color.Gray;  // For testing and also to make sure all fields are handled.
            maskedBox.Font = new Font("Microsoft Sans Serif", 10.0f);
            maskedBox.ValidatingType = typeof(System.DateTime);
            maskedBox.BeepOnError = false;
            maskedBox.TypeValidationCompleted += new TypeValidationEventHandler(maskedTextBoxDate_TypeValidationCompleted);
            ...
        }
