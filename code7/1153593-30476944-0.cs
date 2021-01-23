    vScrollBar1.Maximum = MyList.VerticalScroll.Maximum;
    vScrollBar1.SmallChange = MyList.VerticalScroll.SmallChange;
    vScrollBar1.LargeChange = MyList.VerticalScroll.LargeChange;
    vScrollBar1.Scroll += (sender, args) =>
    {
        switch (args.Type)
        {
            case ScrollEventType.ThumbTrack:
                var sum = 0;
                Control prevCtrl = null;
                foreach (Control control in MyList.Controls)
                {
                    if (prevCtrl == null || control.Bottom > prevCtrl.Bottom)
                    {
                        if (args.OldValue >= sum && args.OldValue < sum + control.Height)
                        {
                            MyList.AutoScrollPosition = new Point(0, sum);
                        }
                                
                        sum += control.Height;
                    }
                    prevCtrl = control;
                }
                break;
        }
    }
