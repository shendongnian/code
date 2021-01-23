    // The selector insid CssSelector is to find all input's ID that contains "memo"
    ICollection<IWebElement> listMemo = driver.FindElements(By.CssSelector("input[id*='memo']"));
                   foreach (var item in listMemo)
                    {
                        item.Displayed = false;
                    }
