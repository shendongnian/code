    [TestClass]
    public class EnumTest
    {
        [TestMethod]
        public void FlagsTest()
        {
            var test1 = BonusType.None;
            Assert.That(ContainsDestroyWholeRowColumn(test1), Is.False);
            var test2 = BonusType.DestroyWholeRowColumn;
            Assert.That(ContainsDestroyWholeRowColumn(test2));
            var test3 = BonusType.None | BonusType.DestroyWholeRowColumn;
            Assert.That(ContainsDestroyWholeRowColumn(test3));
            Assert.That(test3 == BonusType.DestroyWholeRowColumn);
            Assert.That(ContainsDestroyWholeRowColumn((BonusType)5));
        }
    }
    [Flags]
    public enum BonusType
    {
        None,
        DestroyWholeRowColumn
    }
    public static bool ContainsDestroyWholeRowColumn(BonusType bt)
    {
        return (bt & BonusType.DestroyWholeRowColumn)
            == BonusType.DestroyWholeRowColumn;
    }
