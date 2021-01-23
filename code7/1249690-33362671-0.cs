            Public Class Messages
                <JsonProperty("message")>
                <JsonConverter(GetType(SingleOrArrayConverter(Of Message)))>
                Public Property Message() As IList(Of Message)
                    Get
                        Return m_Message
                    End Get
                    Set(value As IList(Of Message))
                        m_Message = value
                    End Set
                End Property
                Private m_Message As IList(Of Message)
            End Class
