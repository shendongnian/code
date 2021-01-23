    // Form1 inherits from this class
    public class MyBase : Form
    {
        public MyBase()
        {
            // hookup load event
            this.Load += (s, e) =>
            {
                // check in which state we are
                if (this.DesignMode)
                {
                    this.BackColor = Color.Red;
                }
                else
                {
                    this.BackColor = Color.Green;
                }
            };
        }
    }
