    Sub Main()
        Dim listone As New List(Of demo) 'first list
        Dim listwo As New List(Of demo)   ' second list
        Dim var1 As Integer
        Dim var2 As String
        Dim obj As New demo()           'first object created in list-1
        obj.id = 1
        obj.name = "sumi"
        listone.Add(obj)                'first object inserted in the list-1
        Dim obj1 As New demo()
        obj1.id = 3
        obj1.name = "more"
        listone.Add(obj1)               'Second object inserted in the list-1
        For Each w In listone
            Dim obj3 As New demo()
            var1 = w.id
            obj3.id = var1
            var2 = w.name
            obj3.name = var2
            listwo.Add(obj3)            'looping all objects of list-1 and adding them in list-2 .Hence making both lists identical
        Next
        For Each p In listone      'making change in the list-1 and this change should not be refelected in list-2
            If (p.id = 1) Then
                p.id = 5
            End If
        Next
        For Each z In listone
            Console.WriteLine(z.id)
            Console.WriteLine(z.name)
        Next
        For Each q In listwo
            Console.WriteLine(q.id)
            Console.WriteLine(q.name)
        Next
        Console.ReadLine()
    End Sub
    Class demo
        Public name As String
        Public id As Integer
    End Class
