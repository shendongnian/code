    Private _model As TestModel
    Sub New()
        Me.New(New TestModel)
    End Sub
    Public Sub New(ByVal model As TestModel)
        _model = model
        _sampleCollection = New ObservableCollection(Of String)
        _sampleCollection.Add("one")
        _sampleCollection.Add("two")
        _sampleCollection.Add("three")
        _sampleCollection.Add("four")
    End Sub
    Private _sampleCollection As ObservableCollection(Of String)
    Public Property SampleCollection As ObservableCollection(Of String)
        Get
            Return _sampleCollection
        End Get
        Set(value As ObservableCollection(Of String))
            'Potential Model Calls to update values in DB
            If value IsNot Nothing Then
                _sampleCollection = value
            End If
        End Set
    End Property
    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
    Protected errors As New Dictionary(Of String, List(Of String))
    Protected Sub OnPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
    End Sub
    ' #Region " Validation Plumbing"
    ' Adds the specified error to the errors collection if it is not 
    ' already present, inserting it in the first position if isWarning is 
    ' false. Raises the ErrorsChanged event if the collection changes. 
    Public Sub AddError(ByVal propertyName As String, ByVal [error] As String,
                        ByVal isWarning As Boolean)
        If Not errors.ContainsKey(propertyName) Then _
            errors(propertyName) = New List(Of String)()
        If Not errors(propertyName).Contains([error]) Then
            If isWarning Then
                errors(propertyName).Add([error])
            Else
                errors(propertyName).Insert(0, [error])
            End If
            RaiseErrorsChanged(propertyName)
        End If
    End Sub
    ' Removes the specified error from the errors collection if it is
    ' present. Raises the ErrorsChanged event if the collection changes.
    Public Sub RemoveError(ByVal propertyName As String, ByVal [error] As String)
        If errors.ContainsKey(propertyName) AndAlso
            errors(propertyName).Contains([error]) Then
            errors(propertyName).Remove([error])
            If errors(propertyName).Count = 0 Then errors.Remove(propertyName)
            RaiseErrorsChanged(propertyName)
        End If
    End Sub
    Public Sub RemoveError(ByVal propertyName As String)
        If errors.ContainsKey(propertyName) Then
            errors.Remove(propertyName)
            RaiseErrorsChanged(propertyName)
        End If
    End Sub
    Public Sub RaiseErrorsChanged(ByVal propertyName As String)
        OnPropertyChanged("HasErrors")
        RaiseEvent ErrorsChanged(Me,
            New DataErrorsChangedEventArgs(propertyName))
    End Sub
    Public Event ErrorsChanged As EventHandler(Of DataErrorsChangedEventArgs) _
        Implements INotifyDataErrorInfo.ErrorsChanged
    Public Function GetErrors(ByVal propertyName As String) _
        As System.Collections.IEnumerable _
        Implements INotifyDataErrorInfo.GetErrors
        If (String.IsNullOrEmpty(propertyName) OrElse
            Not errors.ContainsKey(propertyName)) Then Return Nothing
        Return errors(propertyName)
    End Function
    Public ReadOnly Property HasErrors As Boolean _
        Implements INotifyDataErrorInfo.HasErrors
        Get
            Return errors.Count > 0
        End Get
    End Property
