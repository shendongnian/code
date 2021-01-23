    Private t As System.Threading.Timer
    Private counter As Long = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        t = New System.Threading.Timer(Sub() counter += 1)
        t.Change(1000, 1000) ' 1000 (ms): start after 1 second, 1000 (ms): 1 second interval
    End Sub
    Public ReadOnly Property Counts As Long
        Get
            Return counter
        End Get
    End Property
    Public Sub ResetCounter()
        t.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite)
        counter = 0
        t.Change(1000, 1000)
    End Sub
