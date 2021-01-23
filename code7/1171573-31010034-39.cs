    public class MainForm : Form
    {
        private Form2 secondaryForm;
        private Form3 thirdForm;
        public int LatestValue {get; set;}
        public void Form2ButtonClick() // Assume this happens in a button click event on MainWindow.
        {
            this.secondaryForm = new Form2();
            this.secondaryForm.PropertyChanged += this.LatestValueChanged;
            this.secondaryForm.Closing += this.ChildWindowClosing;
        }
        public void Form3ButtonClick() // Assume this happens in a button click event on MainWindow.
        {
            this.thirdForm = new Form3();
            this.thirdForm.PropertyChanged += this.LatestValueChanged;
            this.thirdForm.Closing += this.ChildWindowClosing;
        }
        private void LatestValueChanged(object sender, PropertyChangedEventArgs e)
        {
            // Do your update here.
            if (sender == this.secondaryForm)
            {
                this.LatestValue = this.secondaryForm.LatestValue2;
            }
            else if (sender == this.thirdForm)
            {
                this.LatestValue = this.thirdForm.LatestValue3;
            }
        }
        // Clean up our event handlers when either of the children forms close.
        private void ChildWindowClosing(object sender, ClosingWindowEventHandlerArgs args)
        {
            if (sender == this.secondaryForm)
            {
                this.secondaryForm.Closing -= this.ChildWindowClosing;
                this.secondaryForm.PropertyChanged -= this.LatestValueChanged;
            }
            else if (sender == this.thirdForm)
            {
                this.thirdForm.Closing -= this.ChildWindowClosing;
                this.thirdForm.PropertyChanged -= this.LatestValueChanged;
            }
        }
    }
