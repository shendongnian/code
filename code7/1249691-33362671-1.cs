          Class SingleOrArrayConverter(Of T)
                Inherits JsonConverter
                Public Overrides Function CanConvert(objectType As Type) As Boolean
                    Return (objectType = GetType(List(Of T)))
                End Function
                Public Overrides Function ReadJson(reader As JsonReader, objectType As Type, existingValue As Object, serializer As JsonSerializer) As Object
                    Dim token As JToken = JToken.Load(reader)
                    If token.Type = JTokenType.Array Then
                        Return token.ToObject(Of List(Of T))()
                    End If
                    Return New List(Of T)() From {
                        token.ToObject(Of T)()
                    }
                End Function
                Public Overrides ReadOnly Property CanWrite() As Boolean
                    Get
                        Return False
                    End Get
                End Property
                Public Overrides Sub WriteJson(writer As JsonWriter, value As Object, serializer As JsonSerializer)
                    Throw New NotImplementedException()
                End Sub
            End Class
