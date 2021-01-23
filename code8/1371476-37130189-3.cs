    public static class WindowExtender
    {
        public static bool IsModal(this Window window)
        {
            var fieldInfo = typeof(Window).GetField("_showingAsDialog", BindingFlags.Instance | BindingFlags.NonPublic);
            return fieldInfo != null && (bool)fieldInfo.GetValue(window);
        }
    }
