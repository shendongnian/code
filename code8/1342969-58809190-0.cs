    using System;
    using System.Collections;
    using System.Windows.Forms;
    
    public static class ListViewExtensions
    {
        public static void Randomize(this ListView lv)
        {
            ListView.ListViewItemCollection list = lv.Items;
            Random rng = new Random();
            int n = list.Count;
            lv.BeginUpdate();
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                ListViewItem value1 = (ListViewItem)list[k];
                ListViewItem value2 = (ListViewItem)list[n];
                list[k] = new ListViewItem();
                list[n] = new ListViewItem();
                list[k] = value2;
                list[n] = value1;
            }
            lv.EndUpdate();
            lv.Invalidate();
        }
    }
