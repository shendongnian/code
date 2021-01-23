    Public Class MyComboBox
    Inherits ComboBox
    Public Event ItemAdded As EventHandler
    'Public Event ItemsAdded As EventHandler
    Public Event ItemRemoved As EventHandler
    'Public Event ItemInserted(sender As Object, insertedIndex As Integer, e As EventArgs)
    Private ItemContainer_ As ItemContainer
    Sub New()
        ItemContainer_ = New ItemContainer(Me)
        AddHandler ItemContainer_.ItemAdded, AddressOf ItemContainer_ItemAdded
        'AddHandler ItemContainer_.ItemsAdded, AddressOf ItemContainer_ItemsAdded
        AddHandler ItemContainer_.ItemRemoved, AddressOf ItemContainer_ItemRemoved
        'AddHandler ItemContainer_.ItemInserted, AddressOf ItemContainer_ItemInserted
    End Sub
    Private Sub ItemContainer_ItemAdded(sender As Object, e As EventArgs)
        RaiseEvent ItemAdded(Me, e)
    End Sub
    'Private Sub ItemContainer_ItemsAdded(sender As Object, e As EventArgs)
    '    RaiseEvent ItemsAdded(Me, e)
    'End Sub
    Private Sub ItemContainer_ItemRemoved(sender As Object, e As EventArgs)
        RaiseEvent ItemRemoved(Me, e)
    End Sub
    'Private Sub ItemContainer_ItemInserted(sender As Object, insertedIndex As Integer, e As EventArgs)
    '    RaiseEvent ItemInserted(Me, insertedIndex, e)
    'End Sub
    Public Shadows ReadOnly Property Items As ItemContainer
        Get
            Return ItemContainer_
        End Get
    End Property
    Public Shadows ReadOnly Property Items(index As Integer) As Object
        Get
            Return ItemContainer_.Item(index)
        End Get
    End Property
    Public Class ItemContainer
        Inherits System.Windows.Forms.ComboBox.ObjectCollection
        Public Event ItemAdded As EventHandler
        'Public Event ItemsAdded As EventHandler
        Public Event ItemRemoved As EventHandler
        'Public Event ItemInserted(sender As Object, insertedIndex As Integer, e As EventArgs)
        Private owner_ As ComboBox
        Sub New(owner As ComboBox)
            MyBase.New(owner)
            owner_ = owner
        End Sub
        Public Overloads Sub Add(item As Object)
            owner_.Items.Add(item)
            RaiseEvent ItemAdded(Me, New EventArgs)
        End Sub
        Public Overloads Sub AddRange(item() As Object)
            owner_.Items.AddRange(item)
            'RaiseEvent ItemsAdded(Me, New EventArgs)
            RaiseEvent ItemAdded(Me, New EventArgs)
        End Sub
        Public Overloads Sub Insert(index As Integer, item As Object)
            owner_.Items.Insert(index, item)
            'RaiseEvent ItemInserted(Me, index, New EventArgs)
            RaiseEvent ItemAdded(Me, New EventArgs)
        End Sub
        Public Overloads Sub Remove(item As Object)
            owner_.Items.Remove(item)
            RaiseEvent ItemRemoved(Me, New EventArgs)
        End Sub
        Public Overloads Sub RemoveAt(index As Integer)
            owner_.Items.RemoveAt(index)
            RaiseEvent ItemRemoved(Me, New EventArgs)
        End Sub
        Public Overloads Sub Clear()
            owner_.Items.Clear()
            RaiseEvent ItemRemoved(Me, New EventArgs)
        End Sub
        Public Overloads Function IndexOf(value As Object) As Integer
            Return owner_.Items.IndexOf(value)
        End Function
        Public Overloads Function Contains(value As Object) As Boolean
            Return owner_.Items.Contains(value)
        End Function
        Public Overloads Function GetHashCode() As Integer
            Return owner_.Items.GetHashCode
        End Function
        Public Overloads Function ToString() As String
            Return owner_.Items.ToString
        End Function
        Public Overloads Function GetEnumerator() As System.Collections.IEnumerator
            Return owner_.Items.GetEnumerator
        End Function
        Public Overloads Function Equals(obj As Object) As Boolean
            Return owner_.Items.Equals(obj)
        End Function
        Public Overloads Function Equals(objA As Object, objB As Object) As Boolean
            Return Object.Equals(objA, objB)
        End Function
        Public Overloads Sub CopyTo(Destination() As Object, arrayIndex As Integer)
            owner_.Items.CopyTo(Destination, arrayIndex)
        End Sub
        Public Overloads ReadOnly Property Count As Integer
            Get
                Return owner_.Items.Count
            End Get
        End Property
        Public Overloads ReadOnly Property IsReadOnly As Boolean
            Get
                Return owner_.Items.IsReadOnly
            End Get
        End Property
        Public Overloads ReadOnly Property Item(index As Integer) As Object
            Get
                Return owner_.Items.Item(index)
            End Get
        End Property
    End Class
