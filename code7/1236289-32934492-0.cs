        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);
        private void TimerCheckForListItemsScrollDown(object sender, EventArgs e)
        {
            if (listBox1.Items.Count < 1)
           {
                return;
           }
           int visibleCount = listBox1.ClientSize.Height /
                ((MyListItem)(listBox1.Items[0])).ItemHeight + 1;
           if (listBox1.TopIndex == 0)
               return;
           if (listBox1.TopIndex + visibleCount > listBox1.Items.Count - 5)
           {
               InsertNextBucketOfListItems();
               //Now is the trick
               var p = Cursor.Position;
               //0004- mouse Up
               mouse_event((uint)0x0004, (uint)p.X, (uint)p.Y, 0, UIntPtr.Zero);
           }
       }
