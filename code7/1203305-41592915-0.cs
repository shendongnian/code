    public static class WordDocument
    {
        public static IEnumerable<Field> GetAllFields(this Document _document)
        {
            // Main text story fields (doesn't include fields in headers and footers)
            foreach (Field field in _document.Fields) {
                yield return field;
            }
            foreach (Section section in _document.Sections) {
                // Header fields
                foreach (HeaderFooter header in section.Headers) {
                    foreach (Field field in header.Range.Fields) {
                        yield return field;
                    }
                }
                // Footer fields
                foreach (HeaderFooter footer in section.Footers) {
                    foreach (Field field in footer.Range.Fields) {
                        yield return field;
                    }
                }
            }
        }
    }
    
