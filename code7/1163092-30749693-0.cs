       var list = driver.FindElements(By.CssSelector("a[data-ng-click='addRoom()']")).ToList();
            foreach (var item in list)
            {
                Console.WriteLine(item.Displayed);
                if(item.Displayed)
                {
                    item.Click();
                }
            }
