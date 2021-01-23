    public class MainForm : Form
    {
        private Form2 secondaryForm;
        public int LatestValue {get; set;}
        public void ButtonClick() // Assume this happens in a button click event on MainWindow.
        {
            this.secondaryForm = new Form2();
            secondaryForm.PropertyChanged += this.LatestValueChanged;
        }
        private void LatestValueChanged(object sender, PropertyChangedEventArgs e)
        {
            // Do your update here.
            this.LatestValue = this.secondaryForm.LatestValue2;
        }
    }
