        [Test]
        public void DateLastModifiedUpdatesOnUpdate()
        {
            //Arrange
            var toTest = LossFactoryHelper.Create();
            var lossCheckAndValidationAddStrategy = new LossChangeAndValidationStrategy();
            var now = DateTime.UtcNow;
            var originalValues = toTest.GetValuesNow();
            //Act
            toTest.mny_deductible = -1;
            var currentValues = toTest.GetValuesNow();
            lossCheckAndValidationAddStrategy.Update(toTest, originalValues, currentValues);
            //Assert
            Assert.GreaterOrEqual(toTest.clc_DateLastModified, now);
        }
