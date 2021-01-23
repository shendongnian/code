      protected override void OnResume()
            {
                base.OnResume();
    
                try
                {
                    var userSelectedCulture = new CultureInfo("en-GB");
    
                    Thread.CurrentThread.CurrentCulture = userSelectedCulture;
                }
                catch (Exception exception)
                {
    
                    Console.WriteLine(exception.Message);
                }
            }
