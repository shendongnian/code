    public partial class Form1 : Form
    {
        ...
        private void button3_Click(object sender, EventArgs e)
        {
            // Instantiate the form and assign the FormClosed event
            var form = new Form2(label1.Text);
            form.FormClosed += Form2_FormClosed;
            // Disable button3
            button3.Enabled = false;
            // Show the form
            form.Show();
        }
        // Occurs when Form2 is closed
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Re-enable button3
            button3.Enabled = true;
        }
    }
