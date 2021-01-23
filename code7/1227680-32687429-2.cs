    public partial class EquationBox
    {
     static Random rnd = new Random();
     public EquationBox()
     {
        InitializeComponent();
        lock (rnd)
        {
          this.panel4.BackColor = Color.FromArgb(rnd.Next(257), rnd.Next(257), rnd.Next(257));
        }
      }
    }
