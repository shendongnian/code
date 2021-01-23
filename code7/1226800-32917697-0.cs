    <ClassInterface(ClassInterfaceType.None), ProgId("MySender.Sender")> _
    <Transaction(EnterpriseServices.TransactionOption.NotSupported)> _
    Public Class Sender
    
        Shared Sub New
        
            AddHandler AppDomain.CurrentDomain.ProcessExit, AddressOf MyDisposalCode
        
        End Sub
    
        '....
        
        Shared Sub MyDisposalCode(sender as Object, e as EventArgs)
        
            'My disposal code
        
        End Sub
    
    End Class
