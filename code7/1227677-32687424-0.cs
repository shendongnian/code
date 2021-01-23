    public partial class EquationBox
    {
        private static Random rnd;
        static EquationBox()
        {
            rnd = new Random();
        }
        public EquationBox()
        {
            this.panel4.BackColor = GetRandomColor();
        }
        private Color GetRandomColor()
        {
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            return randomColor;
        }
    }
