    Public  Sub Subscribe(ByVal QueueName As String, ByVal ActiveMQHost As String)
     consumer.Listener += New MessageListener(OnMessage)
    End Sub
     
    Private Shared  Sub OnMessage(ByVal message As IMessage)
     
    End Sub
