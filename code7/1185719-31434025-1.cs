         Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim pp As New List(Of HotKey)
            pp.Add(New HotKey("0", 48))
            pp.Add(New HotKey("1", 49))
            pp.Add(New HotKey("2", 50))
            pp.Add(New HotKey("3", 51))
            pp.Add(New HotKey("4", 52))
            pp.Add(New HotKey("5", 53))
            ListBox1.DataSource = pp
            ListBox1.DisplayMember = "TextName"
            ListBox1.ValueMember = "KeyCode"
        End Sub
    
        Private Sub ListBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox1.KeyPress
            For x = 0 To ListBox1.Items.Count - 1
                Dim pp As HotKey = CType(ListBox1.Items(x), HotKey)
                If Asc(e.KeyChar) = pp.KeyCode Then
                    ListBox1.SelectedIndex = x
                    e.Handled = True
                    Exit For
                End If
            Next
        End Sub
    End Class
    
    Public Class HotKey
        Private _name As String
        Private _key As Integer
        Public Sub New(ByVal textName As String, ByVal keyCode As Integer)
            _name = textName
            _key = keyCode
        End Sub
    
        Public Property TextName As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property
    
        Public Property KeyCode As Integer
            Get
                Return _key
            End Get
            Set(ByVal value As Integer)
                _key = value
            End Set
        End Property
    End Class
