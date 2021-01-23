    var sw2 = Stopwatch.StartNew();
    System.Threading.Thread.Sleep(500);
    string elapsedMs2 = sw2.Elapsed.ToString();
    System.Threading.Thread.Sleep(500);
    string elapsedMs3 = sw2.Elapsed.ToString();
    sw2.Stop();
    TimeSpan s1 = DateTime.Parse(elapsedMs2).TimeOfDay;
    TimeSpan s2 = DateTime.Parse(elapsedMs3).TimeOfDay;
