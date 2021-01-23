        public IWebElement FindElementUsingNestedBy(By firstCriteria, By secondCriteria)
        {
            var allElements = Driver.FindElements(firstCriteria);
            foreach (var webElement in allElements)
            {
                try
                {
                    var desiredObject = webElement.FindElement(secondCriteria);
                    return desiredObject;
                }
                catch (NotFoundException ex)
                {
                    
                }
            }
            return null;
        }
