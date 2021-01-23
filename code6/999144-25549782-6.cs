    Public Class MyObject
       Public Property MyInt() As Integer
       Public Property MyString() As String
    ...
    Dim myList As New List(Of MyObject)()
    myList.Add(New MyObject(1, "Outdoor"))
    myList.Add(New MyObject(2, "Hardware"))
    myList.Add(New MyObject(3, "Tools"))
    myList.Add(New MyObject(4, "Books"))
    myList.Add(New MyObject(5, "Appliances"))
    RadGridView1.DataSource = myList
