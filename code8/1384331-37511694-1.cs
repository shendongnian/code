    Imports System.Data.OleDb
    Imports System.Collections
    Public Class xlsRW
      Public Enum FieldsType As Byte
        [char]
        [date]
        [float]
        [currency]
      End Enum
      Public Structure fldType
        Public fldName As String
        Public fldSize As UShort
        Public fldType As FieldsType
        Public fldValue As Object
      End Structure
      Private blnHasHeader As Boolean = True
      Private strSheetName As String = String.Empty
      Private strFileName As String = String.Empty
    
      Private blnXLSOpen As Boolean = False
      Private oleConn As OleDbConnection
      Private oleCmd As OleDbCommand
      Private oleDA As OleDbDataAdapter
      Private htFields As New Hashtable
    #Region " Properties "
      Public Property FileName() As String
        Get
          Return strFileName
        End Get
        Set(ByVal value As String)
          strFileName = value
        End Set
      End Property
      Public Property SheetName() As String
        Get
          Return strSheetName
        End Get
        Set(ByVal value As String)
          strSheetName = value
        End Set
      End Property
      Public Property HasHeader() As Boolean
        Get
          Return blnHasHeader
        End Get
        Set(ByVal value As Boolean)
          blnHasHeader = value
        End Set
      End Property
      Public ReadOnly Property IsXLSOpen As Boolean
        Get
          Return blnXLSOpen
        End Get
      End Property
    #End Region
      Public Sub Open()
        If strFileName.Length = 0 Then
          Throw New Exception("Filename was not assigned.")
        End If
        Me.Open(strFileName)
      End Sub
      Public Sub Open(ByVal strFileName As String)
        Try
    
          Dim strConn As String = String.Empty
          If IO.Path.GetExtension(strFileName).ToLower = ".xls" Then
            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFileName & ";" & "Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;READONLY=FALSE;"""
          ElseIf IO.Path.GetExtension(strFileName).ToLower = ".xlsx" Then
            strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & strFileName & ";" & "Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1;READONLY=FALSE;"""
          End If
          If Not blnHasHeader Then
            strConn = strConn.Replace("YES", "NO")
          End If
          oleConn = New OleDbConnection
          oleConn.ConnectionString = strConn
    
          oleConn.Open()
          blnXLSOpen = True
        Catch ex As Exception
          Throw ex
        End Try
      End Sub
      Public Sub ColumnAdd(colDef As fldType)
        If htFields.ContainsKey(colDef.fldName) Then
          Throw New Exception("Field already exist")
        End If
        Dim strField As String = String.Empty
        strField = colDef.fldName & " " & colDef.fldType.ToString
        If colDef.fldType = FieldsType.char Then
          strField += " (" & colDef.fldSize & ")"
        End If
        htFields.Add(colDef.fldName, strField)
      End Sub
      Public Sub ColumnRemove(colDefName As String)
        If Not htFields.ContainsKey(colDefName) Then
          Throw New Exception("Field doesn't exist")
        End If
        htFields.Remove(colDefName)
      End Sub
      Public Sub ColumnUpdate(colDef As fldType)
        If Not htFields.ContainsKey(colDef.fldName) Then
          Throw New Exception("Field doesn't exist")
        End If
        Dim strField As String = String.Empty
        strField = colDef.fldName & " " & colDef.fldType.ToString
        If colDef.fldType = FieldsType.char Then
          strField += " (" & colDef.fldSize & ")"
        End If
        htFields.Item(colDef.fldName) = strField
      End Sub
      Public Sub ColumnClear()
        htFields.Clear()
      End Sub
      Public Sub CreateWorkbook(ByVal strSheetName As String)
        If Not blnXLSOpen Then
          Throw New Exception("Connection is unassigned or closed.")
        End If
        If htFields.Count = 0 Then
          Throw New Exception("No fields defined.")
        End If
        Try
          oleCmd = New OleDbCommand
          oleCmd.Connection = oleConn
          Dim strCmdText As String = "CREATE TABLE " & strSheetName & " ("
          For Each strFldDesign As String In htFields.Keys
            strCmdText += htFields(strFldDesign) & ", "
          Next
          oleCmd.CommandText += strCmdText.Substring(0, strCmdText.Length - 2) & ")"
    
          oleCmd.ExecuteNonQuery()
    
        Catch ex As Exception
    
        End Try
      End Sub
      Public Sub Close()
        oleConn.Close()
        blnXLSOpen = False
      End Sub
    #Region " Select "
      Public Function SelectWorksheet() As DataTable
        If Not blnXLSOpen Then
          Throw New Exception("Connection is unassigned or closed.")
        End If
        If strSheetName.Length = 0 Then
          Throw New Exception("Sheetname was not assigned.")
        End If
        Try
          oleDA = New OleDbDataAdapter("select * from [" & strSheetName & "$]", oleConn)
          Dim dsXLS As DataSet = New DataSet(IO.Path.GetFileNameWithoutExtension(strFileName))
          oleDA.Fill(dsXLS)
          dsXLS.Tables(0).TableName = strSheetName
          Return dsXLS.Tables(0)
        Catch ex As Exception
          Throw ex
          Return Nothing
        End Try
      End Function
      Public Function SelectWorksheet(ByVal strCell As String) As Object
        If Not blnXLSOpen Then
          Throw New Exception("Connection is unassigned or closed.")
        End If
        If strSheetName.Length = 0 Then
          Throw New Exception("Sheetname was not assigned.")
        End If
        Dim strCellRange As String = strCell & ":" & strCell
        Try
          oleCmd = New OleDbCommand("SELECT * FROM [" & strSheetName & "$" & strCellRange & "]", oleConn)
          Return oleCmd.ExecuteScalar()
        Catch ex As Exception
          Throw ex
          Return Nothing
        End Try
      End Function
    #End Region
    #Region " Insert "
      Public Sub InsertWorksheet(ByVal aryValues As ArrayList)
        If Not blnXLSOpen Then
          Throw New Exception("Connection is unassigned or closed.")
        End If
        If strSheetName.Length = 0 Then
          Throw New Exception("Sheetname was not assigned.")
        End If
        Try
          Dim oleDA As New OleDbDataAdapter()
          oleCmd = New OleDbCommand("Select * From [" & strSheetName & "$]", oleConn)
          oleDA.SelectCommand = oleCmd
          Dim dsXLS As DataSet = New DataSet(IO.Path.GetFileNameWithoutExtension(strFileName))
          oleDA.Fill(dsXLS, strSheetName)
          Dim strInsertCmd As String = String.Empty
          Dim strColumn As String = String.Empty
          strInsertCmd = "INSERT INTO [" & strSheetName & "$] ("
          For bteCnt As Byte = 0 To dsXLS.Tables(strSheetName).Columns.Count - 1
            strInsertCmd += "[" & dsXLS.Tables(strSheetName).Columns.Item(bteCnt).ColumnName & "], "
          Next
          strInsertCmd = strInsertCmd.Substring(0, strInsertCmd.Length - 2)
          strInsertCmd += ") VALUES ("
          For bteCnt As Byte = 0 To dsXLS.Tables(strSheetName).Columns.Count - 1
            strInsertCmd += "?, "
          Next
          strInsertCmd = strInsertCmd.Substring(0, strInsertCmd.Length - 2) & ")"
          oleDA.InsertCommand = New OleDbCommand(strInsertCmd, oleConn)
          For bteCnt As Byte = 0 To dsXLS.Tables(strSheetName).Columns.Count - 1
            strColumn = dsXLS.Tables(strSheetName).Columns.Item(bteCnt).ColumnName
            Select Case aryValues.Item(bteCnt).GetType.Name
              Case "String"
                oleDA.InsertCommand.Parameters.Add("@" & strColumn, OleDbType.VarChar)
              Case "DateTime"
                oleDA.InsertCommand.Parameters.Add("@" & strColumn, OleDbType.Date)
              Case "Decimal", "Int32"
                oleDA.InsertCommand.Parameters.Add("@" & strColumn, OleDbType.Numeric)
              Case "DBNull"
                oleDA.InsertCommand.Parameters.Add("@" & strColumn, OleDbType.Empty)
            End Select
            oleDA.InsertCommand.Parameters.Item("@" & strColumn).Value = aryValues.Item(bteCnt)
          Next
          oleDA.InsertCommand.ExecuteNonQuery()
          oleDA.Update(dsXLS, strSheetName)
        Catch ex As Exception
          Throw ex
        End Try
      End Sub
      Public Sub InsertWorksheet(ByVal drRow As DataRow)
        If Not blnXLSOpen Then
          Throw New Exception("Connection is unassigned or closed.")
        End If
        If strSheetName.Length = 0 Then
          Throw New Exception("Sheetname was not assigned.")
        End If
        Try
          Dim oleDA As New OleDbDataAdapter()
          oleCmd = New OleDbCommand("Select * From [" & strSheetName & "$]", oleConn)
          oleDA.SelectCommand = oleCmd
          Dim dsXLS As DataSet = New DataSet(IO.Path.GetFileNameWithoutExtension(strFileName))
          oleDA.Fill(dsXLS, strSheetName)
          Dim strInsertCmd As String = String.Empty
          Dim strColumn As String = String.Empty
          strInsertCmd = "INSERT INTO [" & strSheetName & "$] ("
          For bteCnt As Byte = 0 To dsXLS.Tables(strSheetName).Columns.Count - 1
            strInsertCmd += "[" & dsXLS.Tables(strSheetName).Columns.Item(bteCnt).ColumnName & "], "
          Next
          strInsertCmd = strInsertCmd.Substring(0, strInsertCmd.Length - 2)
          strInsertCmd += ") VALUES ("
          For bteCnt As Byte = 0 To dsXLS.Tables(strSheetName).Columns.Count - 1
            strInsertCmd += "?, "
          Next
          strInsertCmd = strInsertCmd.Substring(0, strInsertCmd.Length - 2) & ")"
          oleDA.InsertCommand = New OleDbCommand(strInsertCmd, oleConn)
          For bteCnt As Byte = 0 To dsXLS.Tables(strSheetName).Columns.Count - 1
            strColumn = dsXLS.Tables(strSheetName).Columns.Item(bteCnt).ColumnName
            Select Case drRow.Item(bteCnt).GetType.Name
              Case "String"
                oleDA.InsertCommand.Parameters.Add("@" & strColumn, OleDbType.VarChar)
              Case "DateTime"
                oleDA.InsertCommand.Parameters.Add("@" & strColumn, OleDbType.Date)
              Case "Decimal"
                oleDA.InsertCommand.Parameters.Add("@" & strColumn, OleDbType.Numeric)
            End Select
            oleDA.InsertCommand.Parameters.Item("@" & strColumn).Value = drRow.Item(bteCnt)
          Next
          oleDA.InsertCommand.ExecuteNonQuery()
          oleDA.Update(dsXLS, strSheetName)
        Catch ex As Exception
          Throw ex
        End Try
      End Sub
      Public Sub InsertWorksheet(ByVal dtData As DataTable)
        If Not blnXLSOpen Then
          Throw New Exception("Connection is unassigned or closed.")
        End If
        If strSheetName.Length = 0 Then
          Throw New Exception("Sheetname was not assigned.")
        End If
        Try
          Dim oleDA As New OleDbDataAdapter()
          oleCmd = New OleDbCommand("Select * From [" & strSheetName & "$]", oleConn)
          oleDA.SelectCommand = oleCmd
          Dim dsXLS As DataSet = New DataSet(IO.Path.GetFileNameWithoutExtension(strFileName))
          oleDA.Fill(dsXLS, strSheetName)
          Dim strInsertCmd As String = String.Empty
          Dim strColumn As String = String.Empty
          For Each dtRow As DataRow In dtData.Rows
            strInsertCmd = "INSERT INTO [" & strSheetName & "$] ("
            For bteCnt As Byte = 0 To dsXLS.Tables(strSheetName).Columns.Count - 1
              strInsertCmd += "[" & dsXLS.Tables(strSheetName).Columns.Item(bteCnt).ColumnName & "], "
            Next
            strInsertCmd = strInsertCmd.Substring(0, strInsertCmd.Length - 2)
            strInsertCmd += ") VALUES ("
            For bteCnt As Byte = 0 To dsXLS.Tables(strSheetName).Columns.Count - 1
              strInsertCmd += "?, "
            Next
            strInsertCmd = strInsertCmd.Substring(0, strInsertCmd.Length - 2) & ")"
            oleDA.InsertCommand = New OleDbCommand(strInsertCmd, oleConn)
            For bteCnt As Byte = 0 To dsXLS.Tables(strSheetName).Columns.Count - 1
              strColumn = dsXLS.Tables(strSheetName).Columns.Item(bteCnt).ColumnName
              Select Case dtData.Columns(bteCnt).DataType.Name
                Case "String"
                  oleDA.InsertCommand.Parameters.Add("@" & strColumn, OleDbType.VarChar)
                Case "DateTime"
                  oleDA.InsertCommand.Parameters.Add("@" & strColumn, OleDbType.Date)
                Case "Decimal"
                  oleDA.InsertCommand.Parameters.Add("@" & strColumn, OleDbType.Numeric)
              End Select
              oleDA.InsertCommand.Parameters.Item("@" & strColumn).Value = dtRow.Item(bteCnt)
              'oleDA.InsertCommand.Parameters.Item("@" & strColumn).SourceColumn = strColumn
            Next
            oleDA.InsertCommand.ExecuteNonQuery()
          Next
          oleDA.Update(dsXLS, strSheetName)
        Catch ex As Exception
          Throw ex
        End Try
      End Sub
    #End Region
    #Region " Update "
      Public Sub UpdateWorksheet(ByVal aryFields() As String, aryValues() As Object, strWhere As String)
        If Not blnXLSOpen Then
          Throw New Exception("Connection is unassigned or closed.")
        End If
        If strSheetName.Length = 0 Then
          Throw New Exception("Sheetname was not assigned.")
        End If
        Try
    
    
        Catch ex As Exception
          Throw ex
        End Try
      End Sub
      Public Sub UpdateWorksheet(ByVal strCell As String, objValue As Object)
        If Not blnXLSOpen Then
          Throw New Exception("Connection is unassigned or closed.")
        End If
        If strSheetName.Length = 0 Then
          Throw New Exception("Sheetname was not assigned.")
        End If
        Try
          oleCmd = New OleDbCommand(String.Empty, oleConn)
          oleCmd.CommandText = "UPDATE [" & strSheetName & "$" & strCell & ":" & strCell & "] SET F1 = ?"
          Dim oleType As OleDbType
          Select Case objValue.GetType.Name
            Case "String"
              oleType = OleDbType.VarChar
            Case "DateTime"
              oleType = OleDbType.Date
            Case "Decimal"
              oleType = OleDbType.Numeric
          End Select
          oleCmd.Parameters.Add("@F1", oleType, 0, "F1")
          oleCmd.Parameters(0).Value = objValue
          oleCmd.ExecuteNonQuery()
        Catch ex As Exception
          Throw ex
        End Try
      End Sub
    #End Region
    End Class
