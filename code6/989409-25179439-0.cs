    [TestFixture]
    public class SO25179186
    {
        [Test]
        public void RuntimeMessageContract()
        {
            var adhoc = new AdHoc();
            Extensible.AppendValue<double>(adhoc, 1, 0.0);
            Extensible.AppendValue<int>(adhoc, 2, 1);
            Extensible.AppendValue<string>(adhoc, 3, "2");
            Extensible.AppendValue<bool>(adhoc, 4, true);
            var clone = Serializer.DeepClone(adhoc);
            Assert.AreNotSame(clone, adhoc);
            Assert.AreEqual(0.0, Extensible.GetValue<double>(clone, 1));
            Assert.AreEqual(1, Extensible.GetValue<int>(clone, 2));
            Assert.AreEqual("2", Extensible.GetValue<string>(clone, 3));
            Assert.AreEqual(true, Extensible.GetValue<bool>(clone, 4));
        }
        [ProtoContract]
        class AdHoc : Extensible {}
    }
