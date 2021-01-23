    static void Main(string[] args)
    {
        Thread t = new Thread(StartForm);
        t.Start();
        string text = Console.ReadLine();
        form.UIThread(() => form.richTextBox1.Text += text);
        Console.ReadLine();
    }
    public static Form1 form;
    public static void StartForm()
    {
        form = new Form1();
        Application.EnableVisualStyles();
        Application.Run(form);
    }
    public static void UIThread(this Control control, Action action)
    {
        if (control.InvokeRequired)            // You're access from other thread
        {
            control.BeginInvoke(action);       // Invoke to access UI element
        }
        else
        {
            action.Invoke();
        }
    }
