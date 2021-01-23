    class CustomColorEditor : ColorEditor
    {
        private static Color[] Colors;
        static CustomColorEditor()
        {
            Colors = new Color[]{
                Color.Red, Color.Green, Color.Blue, Color.White, 
                Color.White, Color.White, Color.White, Color.White, 
                Color.White, Color.White, Color.White, Color.White, 
                Color.White, Color.White, Color.White, Color.White, 
            };
        }
        public override object EditValue(ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            var colorEditorObject = this;
            Type colorUiType = typeof(ColorEditor).GetNestedType("ColorUI", BindingFlags.NonPublic);
            var colorUiConstructor = colorUiType.GetConstructors()[0];
            var colorUiField = typeof(ColorEditor).GetField("colorUI", BindingFlags.Instance | BindingFlags.NonPublic);
            var colorUiObject = colorUiConstructor.Invoke(new[] { colorEditorObject });
            colorUiField.SetValue(colorEditorObject, colorUiObject);
            var palField = colorUiObject.GetType().GetField("pal", BindingFlags.Instance | BindingFlags.NonPublic);
            var palObject = palField.GetValue(colorUiObject);
            var palCustomColorsField = palObject.GetType().GetField("customColors", BindingFlags.Instance | BindingFlags.NonPublic);
            palCustomColorsField.SetValue(palObject, Colors);
            var selectedValue = base.EditValue(context, provider, value);
            Colors = palCustomColorsField.GetValue(palObject) as Color[];
            return selectedValue;
        }
    }
