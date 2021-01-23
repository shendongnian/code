    private async void SomeMethodA()
    {
        using (var myContext = new Context()) // or, possibly, new Entities()
        {
            await myContext.GetA();
        }
    }
