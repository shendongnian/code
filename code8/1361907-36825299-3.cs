       public class TestCases {
            [DataDrivenTestMethod]
            [DataRow("NumberOfLoyalHonestWomen", "Number Of Loyal Honest Women")]
            [DataRow("MGTOWSaysThereAreMoreUnicorns", "MGTOW Says There Are More Unicorns")]
            [DataRow("MGTOW1SaysThereAreMoreUnicorns", "MGTOW1 Says There Are More Unicorns")]
            [DataRow("MGTOWSaysThereAreMOREUnicorns", "MGTOW Says There Are MORE Unicorns")]
            [DataRow("MGTOWSaysThereAREMoreUNICORNS", "MGTOW Says There ARE More UNICORNS")]            
            public void ConvertToTitleCase(string stringUnderTest, string expected) {
                var actual = stringUnderTest.ToSentence();
                Assert.AreEqual(expected, actual);
            }
        }
