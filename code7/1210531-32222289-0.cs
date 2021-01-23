    SubsetController controller = new SubsetController(new CConfigRepository(new FakeDataContextRepository()));
    var myBaseClassProtectedProperty=
                controller.GetType().BaseType
                    .GetProperty("CCITenderInfo", BindingFlags.NonPublic | BindingFlags.Instance)
                    .GetValue(controller);
    var myProtectedProperty =
                CCITenderInfo.GetType()
                    .GetProperty("ConfigurationId", BindingFlags.Public |     BindingFlags.Instance)
                    .GetValue(myBaseClassProtectedProperty);
