            var spanCount = driver.FindElements(By.XPath("//*[@id='targetSummaryCount']/span")).Count;
            var myResult = "";
            for (int spanIndex = 0; spanIndex < spanCount; spanIndex++)
            {
                var spanText = driver.FindElement(By.XPath("//*[@id='targetSummaryCount']/span[" + spanIndex + "]")).Text;
                if (spanText != "/")
                {
                    myResult += "span:" + spanIndex + " spanText:" + myResult;
                }
            }
