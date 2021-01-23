     [TestMethod]
     public void TestOrder()
     {
         IList<IWebElement> otherSports = Driver.FindElements(By.CssSelector(".sports-buttons-container .other-sport .sport-name"));
         var x = otherSports.Select(item=>item.Text.Replace(System.Environment.NewLine, ""))
         var sorted = new List<string>();
         sorted.AddRange(x.OrderBy(o=>o));
         Assert.IsTrue(x.SequenceEqual(sorted));
     }
