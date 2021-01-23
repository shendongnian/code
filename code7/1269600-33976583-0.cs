                case StringComparison.OrdinalIgnoreCase:
                    // If both strings are ASCII strings, we can take the fast path.
                    if (strA.IsAscii() && strB.IsAscii()) {
                        return (CompareOrdinalIgnoreCaseHelper(strA, strB));
                    }
                    // Take the slow path.                
                    return TextInfo.CompareOrdinalIgnoreCase(strA, strB); 
