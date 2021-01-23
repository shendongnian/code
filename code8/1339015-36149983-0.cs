    ' This class implements a simple customer type 
    ' that implements the IPropertyChange interface.
    
    Public Class DemoCustomer
        Implements INotifyPropertyChanged
    
        ' These fields hold the values for the public properties.
        Private idValue As Guid = Guid.NewGuid()
        Private customerName As String = String.Empty
        Private companyNameValue As String = String.Empty
        Private phoneNumberValue As String = String.Empty
    
        Public Event PropertyChanged As PropertyChangedEventHandler _
          Implements INotifyPropertyChanged.PropertyChanged
    
        Private Sub NotifyPropertyChanged(ByVal info As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
        End Sub
    
    
        ' The constructor is private to enforce the factory pattern.
        Private Sub New() 
            customerName = "no data"
            companyNameValue = "no data"
            phoneNumberValue = "no data"
    
        End Sub 'New
    
    
        ' This is the public factory method.
        Public Shared Function CreateNewCustomer() As DemoCustomer 
            Return New DemoCustomer()
    
        End Function
    
        ' This property represents an ID, suitable
        ' for use as a primary key in a database.
        Public ReadOnly Property ID() As Guid
            Get
                Return Me.idValue
            End Get
        End Property
    
    
        Public Property CompanyName() As String 
            Get
                Return Me.companyNameValue
            End Get 
            Set
                If value <> Me.companyNameValue Then
                    Me.companyNameValue = value
                    NotifyPropertyChanged("CompanyName")
                End If
            End Set
        End Property
    
        Public Property PhoneNumber() As String 
            Get
                Return Me.phoneNumberValue
            End Get 
            Set
                If value <> Me.phoneNumberValue Then
                    Me.phoneNumberValue = value
                    NotifyPropertyChanged("PhoneNumber")
                End If
            End Set
        End Property
    End Class
