    Public Class Form1
       Private Sub cmdRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRun.Click
          DataGridView1.DataSource = Nothing
    
          Try
    
             Dim ClipboardData As IDataObject = Clipboard.GetDataObject()
    
             If Not ClipboardData Is Nothing Then
    
                'Next proceed only of the copied data is in the CSV format indicating Excel content
                If (ClipboardData.GetDataPresent(DataFormats.CommaSeparatedValue)) Then
    
                   'Cast the copied data in the CommaSeparatedValue format & hold in a StreamReader Object
                   Dim ClipboardStream As New IO.StreamReader(CType(ClipboardData.GetData(DataFormats.CommaSeparatedValue), IO.Stream))
                   Dim FormattedData As String = ""
    
                   'Define a DataTable to hold the copied data for binding to the DataGrid
                   Dim Table As New DataTable With {.TableName = "ExcelData"}
    
                   While (ClipboardStream.Peek() > 0)
                      Dim SingleRowData As Array
    
                      'Multipurpose Loop Counter
                      Dim LoopCounter As Integer = 0
    
                      'Read a line of data from the StreamReader object
                      FormattedData = ClipboardStream.ReadLine()
    
                      Console.WriteLine(FormattedData)
    
                      SingleRowData = FormattedData.Split(",".ToCharArray)
    
                      If Table.Columns.Count <= 0 Then
                         For LoopCounter = 0 To SingleRowData.GetUpperBound(0)
                            Table.Columns.Add()
                         Next
                         LoopCounter = 0
                      End If
    
                      Dim rowNew As DataRow
                      rowNew = Table.NewRow()
    
                      For LoopCounter = 0 To SingleRowData.GetUpperBound(0)
                         rowNew(LoopCounter) = SingleRowData.GetValue(LoopCounter)
                      Next
    
                      LoopCounter = 0
    
                      Table.Rows.Add(rowNew)
    
                      rowNew = Nothing
                   End While
    
                   ClipboardStream.Close()
                   DataGridView1.DataSource = Table
                Else
                   MsgBox("Clipboard data does not seem to be copied from Excel!")
                End If
             Else
                MsgBox("Clipboard is empty!")
             End If
          Catch exp As Exception
             MsgBox(exp.Message)
          End Try
    
       End Sub
       ''' <summary>
       ''' Enable if you wish, it will disable the button "Run" if there is no Excel data
       ''' in the clipboard at start up.
       ''' </summary>
       ''' <param name="sender"></param>
       ''' <param name="e"></param>
       ''' <remarks></remarks>
       Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles MyBase.Load
    
          Dim ClipboardData As IDataObject = Clipboard.GetDataObject()
    
          cmdRun.Enabled = False
    
          If Not ClipboardData Is Nothing Then
             If (ClipboardData.GetDataPresent(DataFormats.CommaSeparatedValue)) Then
                cmdRun.Enabled = True
             End If
          End If
    
          Dim dt As New DataTable With {.TableName = "CustNames"}
    
          dt.Columns.AddRange( _
             New DataColumn() _
                { _
                   New DataColumn("FirstName", GetType(System.String)), _
                   New DataColumn("LastName", GetType(System.String)) _
                } _
             )
    
          dt.Rows.Add(New Object() {"Kevin", "Gallagher"})
          DataGridView1.DataSource = dt
    
       End Sub
       Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
          Close()
       End Sub
    
       Private Sub Form1_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
          Dim dt As New DataTable With {.TableName = "CustNames"}
    
          dt.Columns.AddRange( _
             New DataColumn() _
                { _
                   New DataColumn("FirstName", GetType(System.String)), _
                   New DataColumn("LastName", GetType(System.String)) _
                } _
             )
    
          dt.Rows.Add(New Object() {"", ""})
          DataGridView1.DataSource = dt
       End Sub
    
       Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
          Try
             Dim ClipboardData As IDataObject = Clipboard.GetDataObject()
             If Not ClipboardData Is Nothing Then
                If (ClipboardData.GetDataPresent(DataFormats.CommaSeparatedValue)) Then
                   Dim ClipboardStream As New IO.StreamReader(CType(ClipboardData.GetData(DataFormats.CommaSeparatedValue), IO.Stream))
                   Dim FormattedData As String = ""
    
                   'Define a DataTable to hold the copied data for binding to the DataGrid
                   Dim Table As New DataTable With {.TableName = "ExcelData"}
    
                   While (ClipboardStream.Peek() > 0)
                      Dim SingleRowData As Array
                      Dim LoopCounter As Integer = 0
    
                      FormattedData = ClipboardStream.ReadLine()
                      SingleRowData = FormattedData.Split(",".ToCharArray)
    
                      If Table.Columns.Count <= 0 Then
                         For LoopCounter = 0 To SingleRowData.GetUpperBound(0)
                            Table.Columns.Add()
                         Next
                         LoopCounter = 0
                      End If
    
                      Dim rowNew As DataRow
                      rowNew = Table.NewRow()
    
                      For LoopCounter = 0 To SingleRowData.GetUpperBound(0)
                         rowNew(LoopCounter) = SingleRowData.GetValue(LoopCounter)
                      Next
    
                      LoopCounter = 0
    
                      Table.Rows.Add(rowNew)
    
                      rowNew = Nothing
                   End While
    
                   ClipboardStream.Close()
                   '
                   ' No assertion done here for ensuring
                   ' the user is attempting to paste valid
                   ' data or that they are no duplicating data
                   '
                   If Table.Columns.Count = 2 Then
                      Dim dt As DataTable = CType(DataGridView1.DataSource, DataTable)
                      For Each row As DataRow In Table.Rows
                         Dim rowNew As DataRow
                         rowNew = dt.NewRow()
                         rowNew("FirstName") = row(0).ToString
                         rowNew("LastName") = row(1).ToString
                         dt.Rows.Add(rowNew)
                      Next
                   End If
                Else
                   MessageBox.Show("Clipboard data does not seem to be copied from Excel!")
                End If
             Else
                MessageBox.Show("Clipboard is empty!")
             End If
          Catch exp As Exception
             MessageBox.Show(exp.Message)
          End Try
       End Sub
    End Class
