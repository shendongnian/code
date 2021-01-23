        private void panel2_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(typeof(TableLayoutPanel))) e.Effect = DragDropEffects.Move;
        }
        private void panel2_DragDrop(object sender, DragEventArgs e) {
            var tlp = (TableLayoutPanel)e.Data.GetData(typeof(TableLayoutPanel));
            tlp.Location = panel2.PointToClient(new Point(e.X, e.Y));
            tlp.Parent = panel2;
            tlp.BringToFront();
        }
