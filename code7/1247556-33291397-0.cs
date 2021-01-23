        mbLoadEng = True
        Dim rowEng As DataRow
        dgvEngine.RowCount = 0
        If dgvEngines.SelectedRows.Count = 0 Then Exit Sub
        Dim sID As String = dgvEngines.SelectedRows(0).Cells(0).Value
        Dim a() As String
        Dim iRow As Integer
        Dim sWhere As String = " WHERE ID=" & sID
        Try
            Dim SQL As String = "SELECT  bYear, bMake, bModel, bSerial_Number, bEquipment_ID, bFuel_Type, bPower_Rating, bCyl, bLoad_Factor, bFuel_Consumption_Factor, "
            SQL &= "   bUnit_Conversion_Factor, bEmission_Category, bEmission_Family, bNOx_Emfac, bROG_Emfac, bPM_Emfac, bAnnual_Usage, bNOX_Emfac_Units, bROG_Emfac_Units, "
            SQL &= "   bPM_Emfac_Units, bAnnual_Usage_Units, bNotes"
            SQL &= " FROM     Engine_Equipment"
            rowEng = Gen.GetDataTable(SQL & sWhere).Rows(0)
            iRow = 0
            For Each col As DataColumn In rowEng.Table.Columns
                a = {rowEng(col).ToString, ""}
                dgvEngine.Rows.Add(a)
                dgvEngine.Rows(iRow).HeaderCell.Value = col.ColumnName.Substring(1)
                iRow += 1
            Next
            Sql = "SELECT  nYear, nMake, nModel, nSerial_Number, nEquipment_ID, nFuel_Type, nPower_Rating, nCyl, nLoad_Factor, "
            Sql &= "  nFuel_Consumption_Factor, nUnit_Conversion_Factor, nEmission_Category, nEmission_Family, nNOx_Emfac, nROG_Emfac, nPM_Emfac, nAnnual_Usage, "
            Sql &= "  nNOX_Emfac_Units, nROG_Emfac_Units, nPM_Emfac_Units, nAnnual_Usage_Units, nNotes"
            Sql &= " FROM     Engine_Equipment"
            rowEng = Gen.GetDataTable(SQL & sWhere).Rows(0)
            iRow = 0
            For Each col As DataColumn In rowEng.Table.Columns
                dgvEngine(1, iRow).Value = rowEng(col).ToString
                iRow += 1
            Next
            dgvEngine.AutoResizeColumns()
            dgvEngine.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders)
            dgvEngine.ClearSelection()
            dgvEngine.Columns(0).ReadOnly = True
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            mbLoadEng = False
        End Try
