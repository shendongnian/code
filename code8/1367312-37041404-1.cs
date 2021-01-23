      SplashScreenImage.SetValue(Canvas.TopProperty, SplashScreen.ImageLocation.Y);
      if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
      {
          SplashScreenImage.Height = SplashScreen.ImageLocation.Height / ScaleFactor;
          SplashScreenImage.Width = SplashScreen.ImageLocation.Width / ScaleFactor;
      }
      else
      {
          SplashScreenImage.Height = SplashScreen.ImageLocation.Height;
          SplashScreenImage.Width = SplashScreen.ImageLocation.Width;
      }
      storyboard.Begin();
