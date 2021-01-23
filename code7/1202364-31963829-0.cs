    [TestFixture]
     [TestFixtureSetup] // this is where I initialize my WebDriver " new FirefoxDriver(); "
      [Test] //this is my first test
        public void Can_Change_Name_And_Title()
        {
            SidebarNavigation.MyProfile.GoTo();
            ProfilePages.SetNewName("John Doe").SetNewTitle("New Title Test").ChangeNameTitle();
        }
      [Test] //this is my second test
        public void Can_Change_Profile_Picture()
        {
            SidebarNavigation.MyProfile.GoTo();
            ProfilePages.SetNewProfilePicture(Driver.BaseFilePath + "Profile.png").ChangeProfilePicture();
        }
    [TestFixtureTearDown] // this is where I close my driver
