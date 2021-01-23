    Dim SizeAlreadyDecreased As Boolean = False
    Private Sub ElektroListView_Downloads_ClientSizeChanged(sender As Object, e As EventArgs) _
    Handles ElektroListView_Downloads.ClientSizeChanged
        ' Retrieve all the column widths
        Dim AllColumnsWidth As Integer =
            (From col As ColumnHeader In CType(sender.Columns, ListView.ColumnHeaderCollection)
             Select col.Width).Sum
        ' Fix the last column width to fill the not-used blank space when resizing the Form.
        Me.ColumnDownload.Width =
            Me.ColumnDownload.Width + (sender.ClientSize.Width - AllColumnsWidth) - 2
        ' Fix the last column width to increase or decrease the size if a VertivalScrollbar appears.
        If GetScrollbars(sender) AndAlso Not SizeAlreadyDecreased Then
            SizeAlreadyDecreased = True
            ColumnDownload.Width -= SystemInformation.VerticalScrollBarWidth
        ElseIf GetScrollbars(sender) AndAlso SizeAlreadyDecreased Then
            SizeAlreadyDecreased = True
        ElseIf Not GetScrollbars(sender) AndAlso SizeAlreadyDecreased Then
            SizeAlreadyDecreased = False
            ColumnDownload.Width += SystemInformation.VerticalScrollBarWidth
        ElseIf Not GetScrollbars(sender) AndAlso Not SizeAlreadyDecreased Then
            SizeAlreadyDecreased = False
        End If
    End Sub
    Private Const WS_VSCROLL As Integer = &H200000I
    Private Const WS_HSCROLL As Integer = &H100000I
    Private Const GWL_STYLE As Integer = -16I
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function GetWindowLong(
            ByVal hWnd As HandleRef,
            ByVal nIndex As Integer
    ) As Integer
    End Function
    Public Function GetScrollbars(ByVal ctrl As Control) As ScrollBars
        Dim style As Integer = GetWindowLong(New HandleRef(ctrl, ctrl.Handle), GWL_STYLE)
        Dim HScroll As Boolean = ((style And WS_HSCROLL) = WS_HSCROLL)
        Dim VScroll As Boolean = ((style And WS_VSCROLL) = WS_VSCROLL)
        If (HScroll AndAlso VScroll) Then
            Return ScrollBars.Both
        ElseIf HScroll Then
            Return ScrollBars.Horizontal
        ElseIf VScroll Then
            Return ScrollBars.Vertical
        Else
            Return ScrollBars.None
        End If
    End Function
