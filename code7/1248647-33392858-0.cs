    if (_screen == Constants.Screens.Welcome)
    {
        ContentHeader = new HeaderWelcome();
        ContentMain = new MainWelcome();
        ContentFooter = new FooterWelcome();
    }
    else if (_screen == Constants.Screens.Setup)
    {
        ContentHeader = new HeaderSetup();
        ContentMain = new MainSetup();
        ContentFooter = new FooterSetup();
    }
