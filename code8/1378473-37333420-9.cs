       internal static bool IsWhiteSpace(char c)
            {
                UnicodeCategory uc = GetUnicodeCategory(c);
                // In Unicode 3.0, U+2028 is the only character which is under the category "LineSeparator".
                // And U+2029 is th eonly character which is under the category "ParagraphSeparator".
                switch (uc) {
                    case (UnicodeCategory.SpaceSeparator):
                    case (UnicodeCategory.LineSeparator):
                    case (UnicodeCategory.ParagraphSeparator):
                        return (true);
                }
     
                return (false);
            }
