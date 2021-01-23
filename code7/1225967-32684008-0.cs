    public partial class Form1 : Form
    {
        // Variable to store whether button one has been clicked or not
        private bool btnOneClicked = false;
        // ..
        private void btnOne_Click(object sender, EventArgs e)
        {
            // When button one is clicked, execute the code that needs to run before waiting for your second button to be clicked
            LongCodeToExecuteFirst();
            // Set your variable to true to say that button one has been clicked
            btnOneClicked = true;
        }
        private void btnTwo_Click(object sender, EventArgs e)
        {
            // First check if button one has been clicked
            if (btnOneClicked)
            {
                // If it has, execute the rest of the code that needed to be executed after button two was pressed
                LongCodeToExecuteSecond();
                // Reset our button one pressed variable to false
                btnOneClicked = false;
            }
        }
        private void LongCodeToExecuteFirst()
        {
            // Code to execute before button two is pressed
        }
        private void LongCodeToExecuteSecond()
        {
            // Code to execute after button two is pressed
        }
    }
