        [TestMethod]
        public void IsNullable_String_ShouldReturn_True()
        {
            var typ = typeof(string);
            var result = typ.IsNullable();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsNullable_Boolean_ShouldReturn_False()
        {
            var typ = typeof(bool);
            var result = typ.IsNullable();
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsNullable_Enum_ShouldReturn_Fasle()
        {
            var typ = typeof(System.GenericUriParserOptions);
            var result = typ.IsNullable();
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsNullable_Nullable_ShouldReturn_True()
        {
            var typ = typeof(Nullable<bool>);
            var result = typ.IsNullable();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsNullable_Class_ShouldReturn_True()
        {
            var typ = typeof(TestPerson);
            var result = typ.IsNullable();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsNullable_Decimal_ShouldReturn_False()
        {
            var typ = typeof(decimal);
            var result = typ.IsNullable();
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsNullable_Byte_ShouldReturn_False()
        {
            var typ = typeof(byte);
            var result = typ.IsNullable();
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsNullable_KeyValuePair_ShouldReturn_False()
        {
            var typ = typeof(KeyValuePair<string, string>);
            var result = typ.IsNullable();
            Assert.IsFalse(result);
        }
