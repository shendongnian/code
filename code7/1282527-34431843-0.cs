     foreach (Control ctrl in flowLayoutPanel1.Controls.OfType<Label>())
     {
            if (ctrl.Tag.ToString() == pairToDelete.ToString())
            {
                   Controls.Remove(ctrl);
                   ctrl.Dispose();
            }
            if (Convert.ToInt32(ctrl.Tag) > pairToDelete)
            {
                   int decrease = Convert.ToInt32(ctrl.Tag) - 1;
                   ctrl.Tag = decrease;
                   ctrl.Text = decrease + ".";
            }
     }
     foreach (Control ctrl in flowLayoutPanel1.Controls.OfType<RichTextBox>())
     {
            if (ctrl.Tag.ToString() == pairToDelete.ToString())
            {
                   Controls.Remove(ctrl);
                   ctrl.Dispose();
            }
            if (Convert.ToInt32(ctrl.Tag) > pairToDelete)
            {
                   int decrease = Convert.ToInt32(ctrl.Tag) - 1;
                   ctrl.Tag = decrease;
            }
     }
