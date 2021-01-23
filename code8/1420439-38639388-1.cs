        [Theory, AutoData]
        public void MatchByIdTest(
            [Frozen(Matching.PropertyName)]int id,
            StaffItem staffItem,
            RankItem rankItem)
        {
            Assert.Equal(staffItem.Id, rankItem.Id);
            Assert.NotEqual(staffItem.SomeProp, rankItem.SomeProp);
        }
        public class StaffItem
        {
            public int Id { get; set; }
            public int SomeProp { get; set; }
        }
        public class RankItem
        {
            public int Id { get; set; }
            public int SomeProp { get; set; }
        }
