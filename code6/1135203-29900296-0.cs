    class Program
    {
        static void Main(string[] args)
        {
            DialogResult dr;
            
            using (var splash = new SplashForm())
            {
                dr = splash.ShowDialog();
            }
            if (dr == DialogResult.OK)
            {
                Application.Run(new HauntedHouse());
            }
        }
    }
