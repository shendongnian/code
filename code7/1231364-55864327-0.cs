    Private Async Sub BtnSendGmail_Click(sender As Object, e As EventArgs) Handles BtnSendGmail.Click
        Try
            Dim credential As UserCredential = Await GoogleWebAuthorizationBroker.AuthorizeAsync(New ClientSecrets With {
                .ClientId = "---------Your ClientId------------",
                .ClientSecret = "----------Your ClientSecret-----------"
            }, {GmailService.Scope.GmailSend}, "user", CancellationToken.None, New FileDataStore(Me.GetType().ToString()))
            Dim service = New GmailService(New BaseClientService.Initializer() With {
                .HttpClientInitializer = credential,
                .ApplicationName = Me.GetType().ToString()
            })
            Dim plainText As String = "From: sender@gmail.com" & vbCrLf &
                                      "To: dest1@gmail.com," & "dest2@gmail.com" & vbCrLf &
                                      "Subject: This is the Subject" & vbCrLf &
                                      "Content-Type: text/html; charset=us-ascii" & vbCrLf & vbCrLf &
                                      "This is the message text."
            Dim newMsg = New Google.Apis.Gmail.v1.Data.Message With {
                .Raw = EncodeBase64(plainText.ToString())
            }
            service.Users.Messages.Send(newMsg, "me").Execute()
            MessageBox.Show("Message Sent OK")
        Catch ex As Exception
            MessageBox.Show("Message failed :" & vbCrLf & "Source: " & ex.Source & vbCrLf & "HResult: " & ex.HResult & vbCrLf & "Message: " &
                            ex.Message & vbCrLf & "StackTrace: " & ex.StackTrace)
        End Try
    End Sub
    Public Shared Function EncodeBase64(ByVal text As String) As String
        ' Encodes a text-string for sending as an email message
        Dim bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(text)
        Return System.Convert.ToBase64String(bytes).Replace("+"c, "-"c).Replace("/"c, "_"c).Replace("=", "")
    End Function
