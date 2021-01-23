    [Given(@"Given I have CoolData with (.*) , (.*) , (.*) and (.*)")]
        public void GivenIhaveCoolDatawithAnd(string p0, string p1, string p2, string p3)
        {
            var cool = new CoolData
            {
                a= p0,
                b= decimal.Parse(p1),
                c= decimal.Parse(p2),
                d= p3,
            };
        }
