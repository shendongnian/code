    Public  Sub Subscribe(ByVal QueueName As String, ByVal ActiveMQHost As String)
     AddHandler consumer.Listener, AddressOf OnMessage
     End Sub
     
    Private Shared  Sub OnMessage(ByVal message As IMessage)
     
    End Sub
