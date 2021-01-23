        [BsonSerializer(typeof(DictionarySerializer<
            Dictionary<FeatureToggleTypeEnum, LicenseFeatureStateEnum>, 
            EnumStringSerializer<FeatureToggleTypeEnum>,
            EnumStringSerializer<LicenseFeatureStateEnum>>))]
        public Dictionary<FeatureToggleTypeEnum, LicenseFeatureStateEnum> FeatureSettings { get; set; }
