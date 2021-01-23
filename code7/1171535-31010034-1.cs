    public class MainForm : Form
    {
        public void Foo() // Assume this happens in a button click event on MainWindow.
        {
            var form2 = new Form2();
            form2.PropertyChanged += this.LatestValueChanged;
        }
        private void LatestValueChanged(object sender, PropertyChangedEventArgs e)
        {
            // Do your update here.
            int changedValue = this.form2.LatestValue2;
        }
    }
