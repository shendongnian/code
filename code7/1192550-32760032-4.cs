    private Form createDraggingHost(Rectangle bounds) {
        var host = new Form() { FormBorderStyle = FormBorderStyle.None, ControlBox = false, AutoScaleMode = AutoScaleMode.None, Bounds = this.draggingBounds, StartPosition = FormStartPosition.Manual };
        host.BackColor = host.TransparencyKey = Color.Fuchsia;
        var tabRect = this.GetTabRect(this.SelectedIndex);
        var tabImage = new Bitmap(bounds.Width, bounds.Height);
        using (var gr = Graphics.FromImage(tabImage)) {
            gr.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
            gr.FillRectangle(Brushes.Fuchsia, new Rectangle(0, 0, tabRect.Left, tabRect.Height));
            gr.FillRectangle(Brushes.Fuchsia, new Rectangle(tabRect.Right, 0, bounds.Width - tabRect.Right, tabRect.Height));
        }
        host.Capture = true;
        host.MouseCaptureChanged += host_MouseCaptureChanged;
        host.MouseUp += host_MouseCaptureChanged;
        host.MouseMove += host_MouseMove;
        host.Paint += (s, pe) => pe.Graphics.DrawImage(tabImage, 0, 0);
        host.Disposed += delegate { tabImage.Dispose(); };
        return host;
    }
