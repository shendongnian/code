        public void DoSomething(string foo)
        {
            bool failedCreation = false;
            try
            {
                SomeClass obj = SomeClass.CreateItem(target);
            }
            catch (CustomException ex)
            {
                // notify UI of error
                failedCreation = true;
            }
            if (failedCreation)
            {
                // do other stuff.
            }
        }
