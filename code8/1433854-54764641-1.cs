    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "PropertiesKeyTypeDefinition")]
    [Name("PropertiesKeyFormat")]
    [Order(Before = Priority.Default)]
    internal sealed class PropertiesKey : ClassificationFormatDefinition {
        public PropertiesKey() {
            DisplayName = "Properties Key";
            ForegroundColor = ToBrush(EnvironmentColors.ClassDesignerCommentTextColorKey);
        }
     }
