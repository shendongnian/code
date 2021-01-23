    Debug.WriteLine("------------------------------------------------");
    int firstHeight = 0;
    foreach (Message m in this.Controls)
    {
        if (count > 0)
        {
            Debug.WriteLine(m.Height);
            m.Height = firstHeight;
            m.Top = last.Top + firstHeight + _BubbleSpacing + AutoScrollPosition.Y;
            if (VerticalScroll.Visible)
            {
               m.Width = new_width - (_BubbleIndent + _BubbleSpacing + SystemInformation.VerticalScrollBarWidth);
            }
            else
            {
                m.Width = new_width - (_BubbleIndent + _BubbleSpacing);
            }
       }
       else
       {
          firstHeight = m.Height;
       }
       Debug.WriteLine(m.Name + "-" + m.Top + "-" + m.Width);
       last = m;
       count++;
    }
