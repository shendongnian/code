    using System.Globalization;
    using System.Threading;
    ...
    // Set the current culture once on the active thread.
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
    ...
    // Now convert everything using this culture.
    Calculation.Rate = Convert.ToDouble(Console.ReadLine());
