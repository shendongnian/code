     cMenuStrip.Items.Add(
         new ToolStripMenuItem(lbl, btn.BackgroundImage, (s, ea) => {
              var size = btn.Size;
              btn.Size = Size.Empty; // button still will be invisible
              btn.Show(); // make it clickable
              btn.PerformClick();
              btn.Hide();  // hide again
              btn.Size = size; // restore original size
            });
