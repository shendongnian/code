    Namespace Transmitter
        <DataContract(Name:= "Data", [Namespace]:="http://www.MyNameSpace.com")> _
        Public Class DataOut
            <DataMember>
            Public Header As String
            <DataMember>
            Public Content As String
        End Class
    End Namespace
