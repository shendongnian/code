    public enum Language {
        English,
        Italian
    }
    
    public static class LocalizationHelper {
    
        private static IDictionary<string, string> eng2ItalianColor = new Dictionary<string, string> {
            { "Red", "Rosso" },
            { "Black", "Nero" },
            { "Blue", "Azzurro" },
            // other ...
        };
    
        public static string GetColorName(OlCategoryColor color, Language language) {
            var englishColorName = 
                outlookColor.Key.ToString().Remove(0, "olCategoryColor".Length);
            
            if (language == Language.English) {
                return englishColorName;
            }
            else if (language == Language.Italian) {
                if (eng2ItalianColor.ContainsKey(englishColorName))
                    return eng2ItalianColor[englishColorName];
                else
                    throw new ArgumentException(
                        "missing translation from english to italian for color: " + englishColorName);
            }
            else {
                throw new ArgumentException("unsupported language: " + language);
            }
        }
    }
    
    // Then use:
    var colorName = 
        LocalizationHelper.GetColorName(outlookColor.Key, Language.Italian);
