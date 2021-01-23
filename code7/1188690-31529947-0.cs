      Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim y As Integer = 0
        'Get the location to draw a rectangle to'
        If Me.ColumnHeadersVisible And Me.FirstDisplayedCell IsNot Nothing Then
          '                        ---------------------------------------
          ' 
          'y = Me.ColumnHeadersHeight + 1 gives the wrong value as well
          y = Me.GetCellDisplayRectangle(-1, -1, False).Height + 1
        Else
          y = 1
        End If
        e.Graphics.FillRectangle(Brushes.Azure, 1, y, 30, 30)
      End Sub
