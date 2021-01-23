Pier Giorgio, you need to set DataContext of each HubSection to each object of itemlist. Since you are manually creating HubSection, for x items in list, x hubsection will be created. Also, you don't need new list lskMsgs. Just modify foreach loop. Let's say the name of your Hub control is testHubControl.
    foreach(MESSAGIO m in msgs)
    {
      mHubSection = new HubSection();
      mHubSection.ContentTemplate =(DataTemplate)this.Resources["msgTemplate"];
      mHubSection.DataContext = m;
      testHubControl.Sections.Add(mHubSection);
    }
