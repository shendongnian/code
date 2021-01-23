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
            TextBox tbSpell = tb.Tag as TextBox;
            if (tbSpell == null || !tbSpell.SpellCheck.IsEnabled)
            { return; }
            tbSpell.Text = tb.Text.ToLower();
            int indx = 0;
            while (true)
            {
                indx = tbSpell.GetNextSpellingErrorCharacterIndex(indx, LogicalDirection.Forward);
                if (indx > -1)
                {
                    int len = tbSpell.GetSpellingErrorLength(indx);
                    Rect r = tb.GetRectFromCharacterIndex(indx);
                    Rect rEnd = tb.GetRectFromCharacterIndex(indx + len);
                    r.Width = rEnd.Right - r.Right;
                    AdornerSpell ad = new AdornerSpell(tb);
                    ad.drawLocation = r;
                    AdornerLayer.GetAdornerLayer(tb).Add(ad);
                    indx += len;
                }
                else
                { break; }
            }
