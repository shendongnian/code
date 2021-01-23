    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim lstAry As New List(Of String())
        lstAry.Add({"1", "a", "d1"})
        lstAry.Add({"1", "b", "d3"})
        lstAry.Add({"2", "c", "d2"})
        lstAry.Add({"3", "a", "d4"})
        lstAry.Add({"3", "a", "d5"})
        Dim distinctCats = lstAry.Select(Function(x) x(0)).Distinct
        If distinctCats IsNot Nothing Then
            For Each distinctcat As String In distinctCats
                Debug.Print("") 
                Debug.Print(distinctcat)
                Dim catmembers = lstAry.Where(Function(x) (x(0) = distinctcat)).Distinct
                If catmembers IsNot Nothing Then
                    For Each catmember As String() In catmembers
                        Debug.Print(catmember(1) & "   " & catmember(2))
                    Next
                End If
            Next
        End If
    End Sub
