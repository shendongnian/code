        [TestFixture]
        public class when_validating_mapping_config
        {
            [Test]
            public void then_should_assert_mapping_configuration_is_valid()
            {
                // Arrange
                MappingConfig.InitializeMappings(); // this is just however you initialize your mappings.
                // Act
                // Assert
                Mapper.AssertConfigurationIsValid();
            }
        }
