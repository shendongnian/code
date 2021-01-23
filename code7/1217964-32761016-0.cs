    using System.Threading;
    using System.Globalization;
    // Put the following code before InitializeComponent()
    // Sets the culture to US English
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US"); 
    // Sets the UI culture too
    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
