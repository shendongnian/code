        [Theory, AutoConfigNSubstituteData]
        public void MatchByIdTestWithAutoConfigNSubstitute(
            [Frozen(Matching.PropertyName)]int id,
            IDataAccess da)
        {
            var staff = da.GetStaff().First();
            var rank = da.GetRank().First();
            Assert.Equal(staff.Id, rank.Id);
            Assert.NotEqual(staff.SomeProp, rank.SomeProp);
        }
        internal class AutoConfigNSubstituteDataAttribute : AutoDataAttribute
        {
            public AutoConfigNSubstituteDataAttribute()
                : base(new Fixture()
                        .Customize(new AutoNSubstituteCustomization())
                        .Customize(new AutoConfiguredNSubstituteCustomization()))
            {
            }
        }
