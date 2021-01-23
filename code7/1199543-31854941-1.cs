    var MainController = new SomeViewController(UIColor.Black, new CGRect(0, 0, 100, 500));
    var SecondaryController = new SomeViewController(UIColor.Green, new CGRect(150, 0, 100, 500));
    this.AddChildViewController(MainController);
    this.AddChildViewController(SecondaryController);
    this.Add(this.MainController.View);
    this.Add(this.SecondaryController.View);
