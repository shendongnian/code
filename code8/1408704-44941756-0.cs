        [TearDown]
        public void TearDown()
        {
            var argSpecs = SubstitutionContext.Current.DequeueAllArgumentSpecifications();
            if (argSpecs.Any())
            {
                throw new UnexpectedArgumentMatcherException();
            }
        }
