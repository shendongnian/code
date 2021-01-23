        [TestFixture]
        public class when_validating_mapping_config
        {
            [Test]
            public void then_should_assert_mapping_configuration_is_valid()
            {
                // Arrange
                MappingConfig.InitializeMappings(type => type.Assembly);
                // Act
                // Assert
                Mapper.AssertConfigurationIsValid();
            }
        }
