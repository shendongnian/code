            //Remove existing adorners
            AdornerLayer lyr = AdornerLayer.GetAdornerLayer(tb);
            if (lyr != null)
            {
                Adorner[] ads = lyr.GetAdorners(tb);
                if (ads != null)
                {
                    foreach (Adorner ad in lyr.GetAdorners(tb))
                    { lyr.Remove(ad); }
                }
            }
            //Get the shadow textbox from the tag property
            TextBox tbSpell = tb.Tag as TextBox;
            if (tbSpell == null || !tbSpell.SpellCheck.IsEnabled)
            { return; }
            //Make sure we have the latest text
            tbSpell.Text = tb.Text.ToLower();
            //Loop to get all spelling errors starting at index 0
            int indx = 0;
            while (true)
            {
                //Find the spelling error
                indx = tbSpell.GetNextSpellingErrorCharacterIndex(indx, LogicalDirection.Forward);
                if (indx > -1)
                {
                    //Have a match, get the length of the error word
                    int len = tbSpell.GetSpellingErrorLength(indx);
                    //Get a rectangle describing the position of the error to use for drawing the underline
                    Rect r = tb.GetRectFromCharacterIndex(indx);
                    Rect rEnd = tb.GetRectFromCharacterIndex(indx + len);
                    //Modify the rectangle width to the width of the word
                    r.Width = rEnd.Right - r.Right;
                    //Create an adorner for the word and set the 'draw location' property to the rectangle
                    AdornerSpell ad = new AdornerSpell(tb);
                    ad.drawLocation = r;
                    //Add the adorner to the textbox
                    AdornerLayer.GetAdornerLayer(tb).Add(ad);
                    //Increment the index to move past this word
                    indx += len;
                }
                else
                { break; }
            }
