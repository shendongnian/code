    public void method1(object sender, EventArgs e)
    {
        Publisher publisher = (Publisher)sender;
        Console.WriteLine(publisher.Name + " raised event x");
    }
