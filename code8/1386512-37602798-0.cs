    public static class Classifications
    {
        // These are the strings that will be used to form the classification types
        // and bind those types to formats
        public const string ArchiveKey    = "MyProject/ArchiveKey";
        public const string ArchiveKeyVar = "MyProject/ArchiveKeyVar";
        // These MEF exports define the types themselves
        [Export]
        [Name(ArchiveKey)]
        private static ClassificationTypeDefinition ArchiveKeyType = null;
        [Export]
        [Name(ArchiveKeyVar)]
        private static ClassificationTypeDefinition ArchiveKeyVarType = null;
        // These are the format definitions that specify how things will look
        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ArchiveKey)]
        [UserVisible(true)]  // Controls whether it appears in Fonts & Colors options for user configuration
        [Name(ArchiveKey)]   // This could be anything but I like to reuse the classification type name
        [Order(After = Priority.Default, Before = Priority.High)] // Optionally include this attribute if your classification should
                                                                  // take precedence over some of the builtin ones like keywords
        public sealed class ArchiveKeyFormatDefinition : ClassificationFormatDefinition
        {
            public ArchiveKeyFormatDefinition()
            {
                ForegroundColor = Color.FromRgb(0xFF, 0x69, 0xB4);  // pink!
                DisplayName = "This will display in Fonts & Colors";
            }
        }
        
        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ArchiveKeyVar)]
        [UserVisible(true)]
        [Name(ArchiveKey)]
        [Order(After = Priority.Default, Before = Priority.High)]
        public sealed class ArchiveKeyVarFormatDefinition : ClassificationFormatDefinition
        {
            public ArchiveKeyVarFormatDefinition()
            {
                ForegroundColor = Color.FromRgb(0xB0, 0x30, 0x60);  // maroon
                DisplayName = "This too will display in Fonts & Colors";
            }
        }
    }
