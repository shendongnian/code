           WinControls.WinControl = New WinControls.WinWindow
            win.SearchProperties.Add("Name", "Open")
            win.SetFocus()
           WinControls.WinButton = New WinControls.WinButton(win)
            btn.SearchProperties.Add("Name", "My Recent Documents")
             WinControls.WinToolTip = New WinControls.WinToolTip(win)
            Mouse.Hover(btn)
            Trace.WriteLin(btn.ToolTipText)
