            var links = driver.FindElements(By.TagName("a"));
            var Locators = new List<Tuple<Point, string>>();
            foreach (var thing in links)
            {
                var tup = new Tuple<Point, string>(thing.Location, thing.Text);
                Locators.Add(tup);
            }
            foreach (var thing in Locators)
            {
                var pt = thing.Item1;
                var reassess = driver.FindElements(By.TagName("a"));
                var filtered = reassess.ToList<IWebElement>().Where(
                    p =>
                        p.Location == thing.Item1 &&
                        p.Text == thing.Item2 &&
                        p.Displayed == true
                        );
                // Debugger.Break();
                if (filtered.Count() == 0) continue;
                filtered.First().Click();
                driver.WaitForPageToLoad();
                AssessNewPageContent();
                driver.Navigate().Back();
                driver.WaitForPageToLoad();
            }
