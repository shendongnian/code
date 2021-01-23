        s = s.Substring(bracePos + 1);
        bracePos = s.IndexOf("}");
        SyntaxText.Text = s.Substring(0, bracePos);
        s = s.Substring(bracePos + 1);
        bracePos = s.IndexOf("}");
        DescriptionText.Text = s.Substring(0, bracePos);
        s = s.Substring(bracePos + 1);
        ExampleText.Text = s;
