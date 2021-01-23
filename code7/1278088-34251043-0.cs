    public class FormMain
    {
        // Class level fields
        private Form1 timerUp = new Form1();
        private Form2 timerBreak = new Form2();
        private void FormMain_Load(object sender, EventArgs e)
        {
            timerUp.Show();
            timerBreak.Show();
        }
        // Use the class level fields wherever you need to
        private void buttonStart_Click(object sender, EventArgs e)
        {
            timerUp.timer1.Start();
        }
        // Dispose of the class-level fields when MainForm is disposed
        protected void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                timerUp.Dispose();
                timerBreak.Dispose();
            }
        }
    }
