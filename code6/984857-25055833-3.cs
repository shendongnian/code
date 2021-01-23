    public class Input:Form 
    {
        public int Value { get; private set;}
    
        private void cmdOkay_Click(object sender, EventArgs e)
        {
            // improve to use Int32.TryParse
            Value = int.Parse(txtInput.Text));
            this.Hide();
        }
    }
