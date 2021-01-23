    Public Class Builder(Of ItemType)
        Dim Constructor As Func(Of Integer, ItemType)
        Dim Queue As New Queue(Of ItemType)
        Public Sub New(Constructor As Func(Of Integer, ItemType))
            Me.Constructor = Constructor
        End Sub
        Public Function Build(ByRef Item As ItemType) As Builder(Of ItemType)
            Item = Constructor(Queue.Count)
            Queue.Enqueue(Item)
            Return Me
        End Function
        Public Function Items() As IEnumerable(Of ItemType)
            Return Queue
        End Function
    End Class
