    public wizard()
    {
        InitializeComponent();
        var intro = new intro();
        wizardframe.NavigationService.Navigate(intro);
    } // this is the intro page.
    private void ileri_b1_Click(object sender, RoutedEventArgs e)
    {
        string introtest = "intro";
        if (introtest == "intro")
        {
            var wpage2 = new wpage2();
            wizardframe.NavigationService.Navigate(wpage2);
            introtest = "wpage2";
        }
        else if (introtest == "wpage2")
        {        
            string fileName = String.Format(@"{0}\temp\aciklama.txt", Environment.CurrentDirectory);
            StreamWriter file = new StreamWriter(fileName);
            file.Write(attext);
            file.Close(); // this is the "Ileri" Button click event.Just saving file.
        }
