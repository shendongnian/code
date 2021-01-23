        [Then(@"An element with the identifier (.*) is (visible|not visible)")]
        public void ThenAnElementWithTheIdentifierIsVisible(string identifier, string visibility)
        {
            if (visibility.Equals("visible"))
            {
                Debug.WriteLine(string.Format("Starting to wait for element with identifier {0} to be visible.", identifier));
                Driver.WaitUntil(d => d.FindElement(By.Id(identifier))
                                       .Displayed);
            }
            else if (visibility.Equals("not visible"))
            {
                Debug.WriteLine(string.Format("Starting to wait for element with identifier {0} to not be visible.", identifier));
                Driver.WaitUntil(d => !d.FindElement(By.Id(identifier))
                                        .Displayed);
            }
        }
