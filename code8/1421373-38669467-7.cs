    List<string> FinalList = new List <string>();
    foreach (IWebElement val in lstTable)
    {
        ReadOnlyCollection<IWebElement> lstSpecialEle = val.FindElements(By.XPath(".//td/span | .//td/b | .//td/p"));
        var AllTextList = lstSpecialEle.Where(x=>x.Text != null).ToList().Select(El => El.Text).ToList();
         string AllText = String.Join(" ", AllTextList);
         FinalList.Add(AllText);       
    }
    Console.WriteLine(FinalList);
