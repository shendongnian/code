                unsafe {
    #if SILVERLIGHT
                    if ( xmlCharType.IsStartNCNameSingleChar( chars[pos] ) ) {
    #else // Optimization due to the lack of inlining when a method uses byte*
                    if ( ( xmlCharType.charProperties[chars[pos]] & XmlCharType.fNCStartNameSC ) != 0 ) {
    #endif
                        pos++;
                    }
    #if XML10_FIFTH_EDITION
                    else if ( pos + 1 < ps.charsUsed && xmlCharType.IsNCNameSurrogateChar(chars[pos + 1], chars[pos])) {
                        pos += 2;
                    }
    #endif
                    else {
                        goto ParseQNameSlow;
                    }
                }
