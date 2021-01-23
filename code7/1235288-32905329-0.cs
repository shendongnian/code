    using System.Link;
    var blackList = {"LogOff", ...};
    var links = driver
      .FindElements(By.CssSelector("a[href]"))
      .Select(a => a.GetAttribute("href"))
      .Where(u => !blackList.Any(s => s.Contains(u)));
    foreach (string link in links)
    {
      ...
    }
