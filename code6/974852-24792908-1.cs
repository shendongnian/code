    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        DataSet DS = new DataSet();
        Application.Run(new frmHome(DS));
