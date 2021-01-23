        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            // This variable will hold the color of the bottom text - the one saying the count of 
            // the avaliable rooms in your example.
            Brush roomsBrush;
            // Here we override the DrawItemEventArgs to change the color of the selected 
            // item background to one of our preference.
            // I changed to SystemColors.Control, to be more like the list you are trying to reproduce.
            // Also, as I see in your example, the font of the room text part is black colored when selected, and gray
            // colored when not selected. So, we are going to reproduce it as well, by setting the correct color
            // on our variable defined above.
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds,
                    e.Index, e.State ^ DrawItemState.Selected, e.ForeColor, SystemColors.Control);
                roomsBrush = Brushes.Black;
            }
            else
            {
                roomsBrush = Brushes.Gray;
            }
            // Looking more at your example, i noticed a gray line at the bottom of each item.
            // Lets reproduce that, too.
            var linePen = new Pen(SystemBrushes.Control);
            var lineStartPoint = new Point(e.Bounds.Left, e.Bounds.Height + e.Bounds.Top);
            var lineEndPoint = new Point(e.Bounds.Width, e.Bounds.Height + e.Bounds.Top);
            e.Graphics.DrawLine(linePen, lineStartPoint, lineEndPoint);
            // Command the event to draw the appropriate background of the item.
            e.DrawBackground();
            // Here you get the data item associated with the current item being drawed.
            var dataItem = listBox1.Items[e.Index] as Tuple<string, string>;
            // Here we will format the font of the part corresponding to the Time text of your list item.
            // You can change to wathever you want - i defined it as a bold font.
            var timeFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            // Here you draw the time text on the top of the list item, using the format you defined.
            e.Graphics.DrawString(dataItem.Item1, timeFont, Brushes.Black, e.Bounds.Left + 3, e.Bounds.Top + 5);
            // Now we draw the avaliable rooms part. First we define our font.
            var roomsFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
            // And, finally, we draw that text.
            e.Graphics.DrawString(dataItem.Item2, roomsFont, roomsBrush, e.Bounds.Left + 3, e.Bounds.Top + 18);
        }
