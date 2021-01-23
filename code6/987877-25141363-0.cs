        [Test]
        public void Test_NameValueConfigurationSection()
        {
            var section2 = ConfigurationManager.GetSection("dataDictionary") as NameValueCollection;
            var result2 = section2["CLOASEUCDBA_T_CONTACT"];
            Assert.AreEqual("CLOASEUCDBA.T_Contact", result2);
        }
