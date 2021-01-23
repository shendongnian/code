        [Given(@"I have RestAPI '(.*)'")]
        public void GivenIHaveRestAPI(int iterationNumber)
        {
            Console.WriteLine(iterationNumber);
        }
        [When(@"I read '(.*)' and '(.*)'")]
        public void WhenIReadAnd(int iterationNumber, string p1)
        {
            Console.WriteLine(iterationNumber);
        }
        [Then(@"the '(.*)' and results table")]
        public void ThenTheAndResultsTable(int iterationNumber, Table table)
        {
            Console.WriteLine(iterationNumber);
        } 
