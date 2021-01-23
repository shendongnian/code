        public bool PreFilterMessage(ref Message m)
        {
            if ((WM)m.Msg == WM.MOUSEWHEEL)
            {
                // if mouse is over a certain component, prevent scrolling
                if (comboBoxVendors.Bounds.Contains(PointToClient(Cursor.Position)))
                {
                    // return true which says the message is already processed
                    return true;
                }
                
                // which direction did they scroll?
                int delta = 0;
                if ((long)m.WParam >= (long)Int32.MaxValue)
                {
                    var wParam = new IntPtr((long)m.WParam << 32 >> 32);
                    delta = wParam.ToInt32() >> 16;
                }
                else
                {
                    delta = m.WParam.ToInt32() >> 16;
                }
                delta = delta*-1;
                var direction = delta > 0 ? 1 : 0;
                // post message to the control I want scrolled (I am converting the vertical scroll to a horizontal, bu you could just re-send the same message to the control you wanted
                PostMessage(splitContainerWorkArea.Panel2.Handle, Convert.ToInt32(WM.HSCROLL), (IntPtr) direction, IntPtr.Zero);
                   
                // return true to say that I handled the message
                return true;
            }                           
            // message was something other than scroll, so ignore it
            return false;
        }
