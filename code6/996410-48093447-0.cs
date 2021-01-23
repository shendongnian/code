            Dim username As String = ""
            Dim password As String = ""
            Dim usernameTokenId As String = ""
            Dim passwordType As String = ""
            For i As Integer = 0 To OperationContext.Current.IncomingMessageHeaders.Count - 1
                Dim mhi As Channels.MessageHeaderInfo = OperationContext.Current.IncomingMessageHeaders.Item(i)
                Dim headers As Channels.MessageHeaders = OperationContext.Current.RequestContext.RequestMessage.Headers
                If mhi.Name.Equals("Security") Then
                    Dim xr As XmlDictionaryReader = OperationContext.Current.IncomingMessageHeaders.GetReaderAtHeader(i)
                    xr.MoveToContent()
                    While xr.MoveToNextAttribute()
                        Console.Write(" {0}='{1}'", xr.Name, xr.Value)
                    End While
                    Do
                        Select Case xr.NodeType
                            Case XmlNodeType.Element
                                If xr.LocalName.Equals("Username") Then
                                    username = xr.ReadElementContentAsString()
                                End If
                                If xr.LocalName.Equals("Password") Then
                                    password = xr.ReadElementContentAsString()
                                End If
                                While xr.MoveToNextAttribute()
                                    If xr.LocalName.Equals("Id") Then
                                        usernameTokenId = xr.Value
                                    End If
                                    If xr.LocalName.Equals("Type") Then
                                        passwordType = xr.Value
                                    End If
                                End While
                            Case XmlNodeType.Attribute
                                
                                'Case XmlNodeType.Text
                                '    Console.Write(xr.Value)
                                'Case XmlNodeType.EndElement
                                '    Console.Write("</{0}>", xr.Name)
                        End Select
                    Loop While xr.Read()
                End If
                Dim name As String = mhi.Name
            Next
