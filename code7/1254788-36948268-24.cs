    static void Main(string[] args)
    {
        Task.Factory.StartNew(ShowImage);
        Console.ReadLine();
    }
    static void ShowImage()
    {
        var form = new Form
        {                
            BackgroundImage = Image.FromFile("img101.png"),
            BackgroundImageLayout = ImageLayout.Stretch
        };
        
        var parent = GetConsoleHandle();
        var child = form.Handle;
        SetParent(child, parent);
        MoveWindow(child, 50, 50, 250, 200, true);
        Application.Run(form);
    }
