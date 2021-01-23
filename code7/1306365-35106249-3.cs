    [TestMethod]
    public void SubmitNewsGetNews_MessageContainsSubmitItems_SendPleaseSelectType()
    {
        const string SUBMITITEMS = "/submitnews";
        TelegramBotFake fakebot = new TelegramBotFake();
        MainClass instance = new MainClass();
        instance.bot = fakebot; //Assign our fake bot
        instance.message.Text = SUBMITITEMS;
        string expected = "Please select a type news: \n/Elmi\n/Farhangi\n/Honari\n/Amoozeshi\n/Varzeshi\n\n/Return";
        instance.SubmitNewsGetType();
        //By checking faking bot.SendedMessage we sure that right method was executed
        Assert.AreEqual(instance.bot.SendedMessage, expected);
    }
