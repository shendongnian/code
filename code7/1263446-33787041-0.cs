    private void Form1_Load(object sender, EventArgs e)
    {
        string[] args = Environment.GetCommandLineArgs();
        btnNotify.Text = args.Length < 2
            ? "Please provide an argument on the command line"
            : args[1]; // First command-line argument.
    }
