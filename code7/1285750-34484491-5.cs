    Private Sub FillComboBox()
        If cn.State = ConnectionState.Open Then cn.Close()
        cn.ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Juan\Documents\NorthwindSample.accdb;Persist Security Info=False;"
        cn.Open()
        cmb.Name = "cmb"
        cmb.HeaderText = "Employee"
        'query that retrieves all the employee names
        Dim sqlquery As String = "Select [last name] & ' ' &  [first name] as Name " &
                 "From employees order by [last name]"
        'add the query results to the combobox cell in datagridview
        Using comm As OleDbCommand = New OleDbCommand(sqlquery, cn)
            Dim rs As OleDbDataReader = comm.ExecuteReader
            dtable = New DataTable
            dtable.Load(rs)
            cmb.DataSource = dtable
            cmb.DisplayMember = dtable.Columns.Item(0).ColumnName
            cmb.ValueMember = dtable.Columns.Item(0).ColumnName
            DataGridView1.Columns.Add(cmb)
        End Using
        'create other columns
        CreateColumns()
    End Sub
    'Procedure to fill the other cells
    Sub FillCells(cmbValue As String, conn As OleDbConnection)
        'query that retrieves the rest of the fields that matches with the combobox value
        Dim sqlquery2 As String = "Select [Last Name] & ' ' & [First Name] as Name, [e-mail address], [job title], city 
              From employees
        Where [Last Name] & ' ' & [First Name] = '" & cmbValue & "'"
        'Assigns query results to datatable 
        Using comm2 As OleDbCommand = New OleDbCommand(sqlquery2, conn)
            Dim rs As OleDbDataReader = comm2.ExecuteReader
            Dim dt As DataTable = New DataTable
            dt.Load(rs)
            'creates a datarow for the datatable
            Dim dtRow As DataRow
            Dim email As String = ""
            Dim jobtitle As String = ""
            Dim city As String = ""
            'assigns datarow items to variables
            For Each dtRow In dt.Rows
                dtRow.Field(Of String)(dt.Columns.Item(1))
                email = dtRow.Item(1)
                jobtitle = dtRow.Item(2)
                city = dtRow.Item(3)
            Next
            'assigns the index of the current row to the variable
            Dim currentRow As Integer
            currentRow = DataGridView1.CurrentRow.Index
            'fills the cells with the values
            DataGridView1.Item(1, currentRow).Value = email
            DataGridView1.Item(2, currentRow).Value = jobtitle
            DataGridView1.Item(3, currentRow).Value = city
            dt = Nothing
        End Using
    End Sub
    Private Sub DataGridView1_EditingControlShowing(sender As Object, 
            e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        'REMEMBER TO CHANGE THE COLUMN INDEX NUMBER TO YOUR COMBOBOX INDEX!!
        If DataGridView1.CurrentCell.ColumnIndex = 0 Then
            Dim combo As ComboBox = CType(e.Control, ComboBox)
            combo.DropDownStyle = ComboBoxStyle.DropDown
            If (combo IsNot Nothing) Then
                ' Remove an existing event-handler, if present, to avoid adding multiple handlers when the editing control is reused.
                RemoveHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionChangeCommitted)
                RemoveHandler combo.TextChanged, New EventHandler(AddressOf ComboBox_TextChanged)
                RemoveHandler combo.KeyDown, New KeyEventHandler(AddressOf ComboBox_KeyDown)
                ' Add the event handler.
                AddHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionChangeCommitted)
                AddHandler combo.TextChanged, New EventHandler(AddressOf ComboBox_TextChanged)
                AddHandler combo.KeyDown, New KeyEventHandler(AddressOf ComboBox_KeyDown)
            End If
        End If
    End Sub
    Private Sub ComboBox_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim combo As ComboBox = CType(sender, ComboBox)
        FillCells(combo.Text, cn)
    End Sub
    Private Sub ComboBox_TextChanged(sender As Object,
                     e As EventArgs)
        Dim combo As ComboBox = CType(sender, ComboBox)
        FillCells(combo.Text, cn)
    End Sub
    Private Sub ComboBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case (e.KeyCode)
            Case Keys.Tab
                e.Equals(Keys.Return)
        End Select
    End Sub
 
