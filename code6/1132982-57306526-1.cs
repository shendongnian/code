        [TestClass]
        public class EnumUtilsTest : UnitTestBase
        {
            #pragma warning disable CS0612 // Type or member is obsolete
    
            [TestMethod]
            public void GetAllValues_Test()
            {
                var values = EnumUtils.GetAllValues<UnitTestEnumValues>();
                Assert.AreEqual(4, values.Count);
                Assert.AreEqual(UnitTestEnumValues.A, values[0]);
                Assert.AreEqual(UnitTestEnumValues.B_Obsolete, values[1]);
                Assert.AreEqual(UnitTestEnumValues.C, values[2]);
                Assert.AreEqual(UnitTestEnumValues.D_Obsolete, values[3]);
            }
    
            [TestMethod]
            public void GetObsoleteValues_Test()
            {
                var values = EnumUtils.GetObsoleteValues<UnitTestEnumValues>();
                Assert.AreEqual(2, values.Count);
                Assert.AreEqual(UnitTestEnumValues.B_Obsolete, values[0]);
                Assert.AreEqual(UnitTestEnumValues.D_Obsolete, values[1]);
            }
    
            [TestMethod]
            public void GetNonObsoleteValues_Test()
            {
                var values = EnumUtils.GetNonObsoleteValues<UnitTestEnumValues>();
                Assert.AreEqual(2, values.Count);
                Assert.AreEqual(UnitTestEnumValues.A, values[0]);
                Assert.AreEqual(UnitTestEnumValues.C, values[1]);
            }
    
            [TestMethod]
            public void IsObsolete_Test()
            {
                Assert.AreEqual(false, EnumUtils.IsObsolete(UnitTestEnumValues.A));
                Assert.AreEqual(true, EnumUtils.IsObsolete(UnitTestEnumValues.B_Obsolete));
                Assert.AreEqual(false, EnumUtils.IsObsolete(UnitTestEnumValues.C));
                Assert.AreEqual(true, EnumUtils.IsObsolete(UnitTestEnumValues.D_Obsolete));
            }
    
            public enum UnitTestEnumValues
            {
                A,
                [Obsolete]
                B_Obsolete,
                C,
                [Obsolete]
                D_Obsolete
            }
    
    		#pragma warning restore CS0612 // Type or member is obsolete
        }
