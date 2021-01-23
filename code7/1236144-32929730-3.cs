    public void TestMethod()
    {
        var a = new TestClass();
        //a.SampleEvent(); //does not compile
        a.SampleEvent += A_SampleEvent; //subscribe to event
    }
    private void A_SampleEvent()
    {
        Console.Write("Fired"); //fired when FireEvent method called
    }
