    // inherit css from parent tags, as defined in provided CssInheritanceRules or if property = inherit
    IDictionary<String, String> css = t.CSS;
    if (t.Name != null)
    {
        if (t.Name.Equals(HTML.Tag.I) || t.Name.Equals(HTML.Tag.CITE)
            || t.Name.Equals(HTML.Tag.EM) || t.Name.Equals(HTML.Tag.VAR)
            || t.Name.Equals(HTML.Tag.DFN) || t.Name.Equals(HTML.Tag.ADDRESS)) {
                tagCss[CSS.Property.FONT_STYLE] = CSS.Value.ITALIC;
        }
        else if (t.Name.Equals(HTML.Tag.B) || t.Name.Equals(HTML.Tag.STRONG)) {
            tagCss[CSS.Property.FONT_WEIGHT] = CSS.Value.BOLD;
        }
        else if (t.Name.Equals(HTML.Tag.U) || t.Name.Equals(HTML.Tag.INS)) {
            tagCss[CSS.Property.TEXT_DECORATION] = CSS.Value.UNDERLINE;
        }
        else if (t.Name.Equals(HTML.Tag.S) || t.Name.Equals(HTML.Tag.STRIKE) 
                 || t.Name.Equals(HTML.Tag.DEL)) {
                     tagCss[CSS.Property.TEXT_DECORATION] = CSS.Value.LINE_THROUGH;
        }
        else if (t.Name.Equals(HTML.Tag.BIG)) {
            tagCss[CSS.Property.FONT_SIZE] = CSS.Value.LARGER;
        }
        else if (t.Name.Equals(HTML.Tag.SMALL)) {
            tagCss[CSS.Property.FONT_SIZE] = CSS.Value.SMALLER;
        }
    }
