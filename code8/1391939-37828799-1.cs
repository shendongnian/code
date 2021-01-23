    gridData.MasterTableView.DataKeyNames = New String() {"ID_Data"}
    
            Dim intVal As Integer = allCloumnData.Tables(0).Columns.Count
            For a = 0 To intVal - 2
                Dim boundColumn As New GridBoundColumn()
                gridData.MasterTableView.Columns.Add(boundColumn) 
                boundColumn.DataField = allCloumnData.Tables(0).Columns(a).Caption().Trim().ToString()
                boundColumn.HeaderText = allCloumnData.Tables(0).Columns(a).Caption().Trim().ToString()
                boundColumn.UniqueName = allCloumnData.Tables(0).Columns(a).Caption().Trim().ToString()
                boundColumn.ItemStyle.CssClass = "text2"
                boundColumn.HeaderStyle.CssClass = "GridHeader"
                boundColumn.AllowFiltering = True            
            Next
