    public partial class EquationBox
    {
     static Random rnd = new Random();
     public EquationBox()
     {
        InitializeComponent();
        lock (rnd)
        {
          this.panel4.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }
      }
    }
