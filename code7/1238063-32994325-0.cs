    internal class MyBaseActivity : Activity
    {
        protected override void OnResume ()
        {
            base.OnResume ();
    
            // Here you would read it from where ever.
            var userSelectedCulture = new CultureInfo ("fr-FR");
    
            Thread.CurrentThread.CurrentCulture = userSelectedCulture;
        }
    }
