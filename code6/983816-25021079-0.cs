    using System.Drawing;
    //...
    //...
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            F1 = new Form1();
            Application.Run(F1);
        }
        static Form1 F1;
        public static void ChangeColor(Color newColor)
        {
            F1.BackColor = newColor;
        }
    }
