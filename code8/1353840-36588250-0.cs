    static Hashtable _tagMap;
    Type ITagNameToTypeMapper.GetControlType(string tagName, IDictionary attributeBag) {
        Type controlType;
        if (_tagMap == null) {
            Hashtable t = new Hashtable(10, StringComparer.OrdinalIgnoreCase);
            t.Add("a", typeof(HtmlAnchor));
            t.Add("button", typeof(HtmlButton));
            t.Add("form", typeof(HtmlForm));
            // [and much more...]
            _tagMap = t;
        }
        // [...]
    }
