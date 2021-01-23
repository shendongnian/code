      Clock clock;
      void SetUpClock()
      {
          clock = new Clock(t => tbkTime.Text = t.ToString("HH:mm", CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.IetfLanguageTag)));        
          clock.Start();
       }
       void StopClock()
       {
           clock.Stop();
       }
