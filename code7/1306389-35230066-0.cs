    public class ThemeSelector : DependencyObject
    {
        public static void ApplyTheme(Uri dictionaryUri)
        {
            var targetElement = Application.Current;
            if (targetElement == null || dictionaryUri == null) return;
            try
            {
                // find if the target element already has a theme applied
                var existingDictionaries =
                    (from dictionary in targetElement.Resources.MergedDictionaries.OfType<ThemeResourceDictionary>()
                     select dictionary).ToList();
                // remove the existing dictionaries 
                foreach (var thDictionary in existingDictionaries)
                {
                    targetElement.Resources.MergedDictionaries.Remove(thDictionary);
                }
                // add the new dictionary to the collection of merged dictionaries of the target object, needs to be added to the end to overwrite the other items
                targetElement.Resources.MergedDictionaries.Add(new ThemeResourceDictionary { Source = dictionaryUri });
            }
            finally { }
        }
    }
