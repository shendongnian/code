    Public Class Form1
    
        Dim data As New List(Of Product)
    
        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    
            Dim bs1 As New BindingSource(data, Nothing)
            Dim bc1 As New BindingContext()
            ComboBox1.BindingContext = bc1
            ComboBox1.DataSource = bs1.DataSource
            ComboBox1.DisplayMember = "ProductName"
    
            Dim bs2 As New BindingSource(data, Nothing)
            Dim bc2 As New BindingContext()
            ComboBox2.BindingContext = bc2
            ComboBox2.DataSource = bs2.DataSource
            ComboBox2.DisplayMember = "ProductName"
    
        End Sub
    
        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    
            For intCounter As Integer = 1 To 10
                data.Add(New Product(intCounter, intCounter.ToString))
            Next
    
        End Sub
    End Class
    
    
    Public Class Product
    
        Public Property ProductID As Integer = 0
        Public Property ProductName As String = String.Empty
    
        Public Sub New(ID As Integer, Name As String)
    
            Me.ProductID = ID
            Me.ProductName = Name
        End Sub
    
    End Class
