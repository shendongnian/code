     private static bool IsWhiteSpaceLatin1(char c) {
     
                // There are characters which belong to UnicodeCategory.Control but are considered as white spaces.
                // We use code point comparisons for these characters here as a temporary fix.
            
                // U+0009 = <control> HORIZONTAL TAB
                // U+000a = <control> LINE FEED
                // U+000b = <control> VERTICAL TAB
                // U+000c = <contorl> FORM FEED
                // U+000d = <control> CARRIAGE RETURN
                // U+0085 = <control> NEXT LINE
                // U+00a0 = NO-BREAK SPACE
                if ((c == ' ') || (c >= '\x0009' && c <= '\x000d') || c == '\x00a0' || c == '\x0085') {
                    return (true);
                }
                return (false);
            }
