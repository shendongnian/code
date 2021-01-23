    public static string ConvertRtfToHtml(RichEditBox richEditbx)
        {
            // Takes a RichEditBox control and returns a
            // simple HTML-formatted version of its contents
            string strHTML, strFont, strColour, strBold, strUnderline, strFntName;
            float shtSize;
            int lngOriginalStart, lngOriginalLength;
            int intCount;
            // string txtDoc;
            string text;
            richEditbx.Document.GetText(TextGetOptions.None, out text);
            ITextRange tr = richEditbx.Document.GetRange(0, text.Length);
            // If nothing in the box, exit
            //if (tr.Length == 0)
            //{
            //    App.Current.Exit();
            //}
            // Store original selections, then select first character
            lngOriginalStart = tr.StartPosition;
            lngOriginalLength = tr.EndPosition;
            tr.SetRange(tr.StartPosition, tr.EndPosition);
            // Add HTML header
            strHTML = "<html>";
            // Set up initial parameters
            strColour = tr.CharacterFormat.ForegroundColor.ToString();
            strFont = tr.CharacterFormat.FontStyle.ToString();
            shtSize = tr.CharacterFormat.Size;
            strBold = tr.CharacterFormat.Bold.ToString();
            strUnderline = tr.CharacterFormat.Underline.ToString();
            strFntName = tr.CharacterFormat.Name;
            // Debug.WriteLine("Colour: " + strColour);
            // Include first 'style' parameters in the HTML
            strHTML += "<span style=\"font-family:" + strFntName + "; font-size: " + shtSize + "pt; color: #" + strColour.Substring(3) + "\">";
            // Include bold tag, if required
            if (strBold.ToLower() == "on")
                strHTML += "<b>";
            if (strUnderline.ToLower() == "single")
            {
                strHTML += "<u>";
            }
            // Include italic tag, if required
            if (strFont.ToLower() == "italic")
                strHTML += "<i>";
            // Finally, add our first character
            strHTML += tr.Character;
            // Loop around all remaining characters
            for (intCount = lngOriginalStart + 2; intCount < lngOriginalLength; intCount++)
            {
                // Select current character
                tr.SetRange(intCount - 1, intCount + 1);
                //     If this is a line break, add HTML tag
                if (tr.Character == Convert.ToChar(13))
                    strHTML += "<br />";
                //     Check/implement any changes in style
                if (tr.CharacterFormat.ForegroundColor.ToString() != strColour || tr.CharacterFormat.Name != strFntName || tr.CharacterFormat.Size != shtSize)
                {
                    strHTML += "</span><span style=\"font-family: " + tr.CharacterFormat.Name + "; font-size: " + tr.CharacterFormat.Size + "pt; color: #" + tr.CharacterFormat.ForegroundColor.ToString().Substring(3) + "\">";
                }
                //     Check for bold changes
                if (tr.CharacterFormat.Bold.ToString().ToLower() != strBold.ToLower())
                {
                    if (tr.CharacterFormat.Bold.ToString().ToLower() != "on")
                        strHTML += "</b>";
                    else
                        strHTML += "<b>";
                }
                if (tr.CharacterFormat.Underline.ToString().ToLower() != strUnderline.ToLower())
                {
                    if (tr.CharacterFormat.Underline.ToString().ToLower() != "single")
                        strHTML += "</u>";
                    else
                        strHTML += "<u>";
                }
                //    Check for italic changes
                if (tr.CharacterFormat.FontStyle.ToString().ToLower() != strFont.ToLower())
                {
                    if (tr.CharacterFormat.FontStyle.ToString().ToLower() != "italic")
                        strHTML += "</i>";
                    else
                        strHTML += "<i>";
                }
                //    Add the actual character
                strHTML += tr.Character;
                //    Update variables with current style
                strColour = tr.CharacterFormat.ForegroundColor.ToString();
                strFont = tr.CharacterFormat.FontStyle.ToString();
                shtSize = tr.CharacterFormat.Size;
                strFntName = tr.CharacterFormat.Name;
                strBold = tr.CharacterFormat.Bold.ToString();
                strUnderline = tr.CharacterFormat.Underline.ToString();
            }
            // Close off any open bold/italic tags
            if (strBold == "on")
                strHTML += "</b>";
            if (strUnderline == "single")
                strHTML += "</u>";
            if (strFont.ToLower() == "italic")
                strHTML += "</i>";
            // Terminate outstanding HTML tags
            strHTML += "</span></html>";
            // Restore original RichTextBox selection
            tr.SetRange(lngOriginalStart, lngOriginalLength);
            return strHTML;
            // Return HTML
            //richeditbox.Document.SetText(TextSetOptions.FormatRtf, strHTML);
        }
