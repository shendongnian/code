    [STAThread]
    static void Main()
    {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         CustomApplicationContext app = new CustomApplicationContext(new Form2(),new Form1());
         Application.Run(app);
             
    }
