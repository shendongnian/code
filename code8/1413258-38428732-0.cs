     private void btnNotes_Click(object sender, EventArgs e)
        {
            if (_editor == null)
            {
                _editor = new VimControl();
                _editor.Location = new Point(400, 200);
                _editor.Size = _editor.MinimumSize;
                _editor.vimTextBox.Text = "Hello World!";
                _editor.vimTextBox.MouseDown += HandleMouseDown;
                _editor.vimTextBox.MouseMove += HandleMouseMove;
                _editor.vimTextBox.MouseUp += HandleMouseUp;
                this.SuspendLayout();
                this.Controls.Add(_editor);
                _editor.BringToFront();
                this.ResumeLayout(true);
            }
    
            _editor.Show();
    
    
        }
    #region Drag Child
    private Point? _mouseDown = null;
    private Point? _mouseLast = null;
    private Control frame = null;
    /// <summary>
    /// Control click to begin drag child.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandleMouseDown(object sender, MouseEventArgs e)
    {
        var child = sender as Control;
        Log.Message("Sender: {0}", child == null ? "Unknown" : child.Name);
        Log.Message("{0} MouseDown at ({1}, {2})", e.Button, e.X, e.Y);
        if (e.Button == MouseButtons.Left && (Control.ModifierKeys & Keys.Control) == Keys.Control)
        {
            _mouseDown = e.Location;
            _mouseLast = e.Location;
            frame = FormHelper.FrameControl(_editor.Size, _editor.Location);
            this.Controls.Add(frame);
            frame.BringToFront();
        }
    }
    private void HandleMouseMove(object sender, MouseEventArgs e)
    {
        var child = sender as Control;
        Log.Message("Sender: {0}", child == null ? "Unknown" : child.Name);
        if (child == null) return;
        if (_mouseDown.HasValue)
        {
            Point delta = MyMath.Delta(_mouseLast.Value, e.Location);
            frame.Left = frame.Left + delta.X;
            frame.Top = frame.Top + delta.Y;
            _mouseLast = e.Location;
        }
    }
    private void HandleMouseUp(object sender, MouseEventArgs e)
    {
        var child = sender as Control;
        Log.Message("My {0} MouseUp at ({1}, {2})", e.Button, e.X, e.Y);
        if (e.Button == MouseButtons.Left && _mouseDown.HasValue)
        {
            _mouseDown = null;
            _mouseLast = e.Location;
            this.SuspendLayout();
            {
                child.Location = frame.Location;
                this.Controls.Remove(frame);
                frame.Dispose();
                frame = null;
            }
            this.ResumeLayout(true);
            child.Show();
        }
    }
    #endregion
