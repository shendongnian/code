        public static void addHovertip(ToolStripStatusLabel lb, Control c, string tip)
        {
            c.MouseEnter += (sender, e) =>
            {
                Debug.WriteLine(String.Format("enter {0}", c));
                lb.Text = tip;
            };
            c.MouseLeave += (sender, e) =>
            {
                Debug.WriteLine(String.Format("Leave {0}", c));
                lb.Text = "";
            };
            // iterate over any child controls
            foreach(Control child in c.Controls)
            {
                // and add the hover tip on 
                // those childs as well
                addHovertip(lb, child, tip);
            }
        }
