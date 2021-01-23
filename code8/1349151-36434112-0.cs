    public void AddSplitButton(RibbonPanel panel)
    {
      // Create three push buttons for split button drop down 
    
      // #1 
      PushButtonData pushButtonData1 = new PushButtonData("SplitCommandData", "Command Data", _introLabPath, _introLabName + ".CommandData");
      pushButtonData1.LargeImage = NewBitmapImage("ImgHelloWorld.png");
    
      // #2 
      PushButtonData pushButtonData2 = new PushButtonData("SplitDbElement", "DB Element", _introLabPath, _introLabName + ".DBElement");
      pushButtonData2.LargeImage = NewBitmapImage("ImgHelloWorld.png");
    
      // #3 
      PushButtonData pushButtonData3 = new PushButtonData("SplitElementFiltering", "ElementFiltering", _introLabPath, _introLabName + ".ElementFiltering");
      pushButtonData3.LargeImage = NewBitmapImage("ImgHelloWorld.png");
    
      // Make a split button now 
      SplitButtonData splitBtnData = new SplitButtonData("SplitButton", "Split Button");
      SplitButton splitBtn = panel.AddItem(splitBtnData) as SplitButton;
      splitBtn.AddPushButton(pushButtonData1);
      splitBtn.AddPushButton(pushButtonData2);
      splitBtn.AddPushButton(pushButtonData3);
    }
