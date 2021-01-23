     [Test]
            [TestCase("Time", Dimension.Time)]
            [TestCase("Location", Dimension.Location)]
            public void ShouldGetProperEnumValue(string enumValueName, Dimension expected)
            {
                var eValue = QuestionnaireGrammar.Dimension.Parse(enumValueName);
                Assert.AreEqual(expected, eValue);
            }
    
            [Test]
            [ExpectedException]
            [TestCase("Fredo")]
            public void ShouldFailIfNotInList(string enumValueName)
            {
                var eValue = QuestionnaireGrammar.Dimension.Parse(enumValueName);
            }
