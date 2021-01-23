            Dim totalWdith As Integer = SOlistview.Width
            Dim combinedColumnWidth As Integer = 0
            Dim visibleSpaceLeft As Integer = 0
    
            Dim columnCount As Integer = SOlistview.Columns.Count
            Dim weHaveClipping As Boolean = False
    
            '//measure the first item... the listviewitem.text property
    
            For i = 0 To columnCount - 1
    
                If combinedColumnWidth + SOlistview.Columns(i).Width > totalWdith Then
    
                    '//we will have clipping occur if we add this column...
                    visibleSpaceLeft = SOlistview.Width - combinedColumnWidth
                    weHaveClipping = True
                    Exit For
    
                Else
    
                    '//no clipping yet, so add this column to my math
                    combinedColumnWidth += SOlistview.Columns(i).Width
    
                End If
    
            Next
    
            Dim myDropDown As New ComboBox
    
            If weHaveClipping Then
                myDropDown.Top = e.Y - myDropDown.Height
                myDropDown.Left = combinedColumnWidth
                myDropDown.Width = visibleSpaceLeft
            Else
                '//run your normal code to place the combobox....
            End If
    
    
            SOlistview.Controls.Add(myDropDown)
