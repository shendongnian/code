    void Main()
    {
        var mainScreenArea = Screen.PrimaryScreen.WorkingArea;
    
        var rich1 = new RichTextBoxEx() { Width = mainScreenArea.Width / 2 - 10, Dock = DockStyle.Left };
        var rich2 = new RichTextBoxEx() { Width = mainScreenArea.Width / 2 - 10, Dock = DockStyle.Right };
        rich1.LoadFile(__RTF_FILE_0__);
        rich2.LoadFile(__RTF_FILE_1__);
    
        // pick one :
        // synchronize by focus
        rich1.FocusChanged += (s, e) => rich2.ScrollToLine(rich1.GetFirstSelectedLine());
        // synchronize by viewbox
        // rich1.VScroll += (s, e) => rich2.ScrollToLine(rich1.GetFirstVisibleLine());
        
        var form = new Form();
        form.Controls.Add(rich1);
        form.Controls.Add(rich2);
    
        form.WindowState = FormWindowState.Maximized;
        form.ShowDialog()
    }
