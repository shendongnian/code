        bool flag = false;
        foreach (RectangleF rec in allRectangles)
        {
            if (rec.Contains(e.Location))
            {
                this.Cursor = Cursors.Hand;
                flag = true;
            }
        }
       if (!flag)     this.Cursor = Cursors.Default;
