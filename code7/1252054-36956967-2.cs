    [TestClass]
    public class ApplicationVariablesTests {
    
        public class FakeApplicationSettings : IApplicationSettings {
            Dictionary<string,object> Application = new Dictionary<string,object>();
            public string this[string keyToReturn] {
                get { return Application[keyToReturn]; }
                set { Application[keyToUpdate] = value; }
            }    
        }
    
        [TestMethod]
        public void Should_Update_General_Settings() {
            //Arrange
            SomeUtilityClass.Application = new FakeApplicationSettings();
            SomeUtilityClass.UpdateApplicationVariable("GeneralSettings", new GeneralSettings()
            {
                NumberDecimalPlaces = 2
            });
            //Act
            GeneralSettings settings = SomeUtilityClass.GetApplicationVariable("GeneralSettings") as GeneralSettings;
            //Assert
            Assert.IsNotNull(settings);
            Assert.AreEqual(2, settings.NumberDecimalPlaces);
        }
    }
