    public static class PropertyValidator {
        public static bool Required<T>(T property) where T: class {
            // I think you want to check this?
            return property != nil;
        }
        public static bool ContainsNumeric(string property) {
            return ...
        }
        public static bool ContainsDate(string property) {
            return ...
        }
        public static bool ContainsChar(string property) {
            return ...
        }
        ...
    }
