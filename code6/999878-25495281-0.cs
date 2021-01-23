        scrollPanel.SizeChanged += delegate {
            //Size s = scrollPanel.Size;
            Size s = scrollPanel.ClientSize;
            int minWidth = 400;
            int minHeight = 400;
            panel.Size = new Size(Math.Max(minWidth, s.Width), Math.Max(minHeight, s.Height));
            // this is a little better, but still will show a scrollbar unnecessarily
            // one side is less but the other side is >=.
            scrollPanel.AutoScroll = (s.Width < minWidth || s.Height < minHeight);
        };
