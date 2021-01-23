    Private Delegate Sub SetTextCallback2(ByVal text As String)
    
        Private Sub SetText2(ByVal text As String)
            Try
                If Me.RichTextBox1.InvokeRequired Then
                    Dim d As New SetTextCallback2(AddressOf SetText2)
                    Me.Invoke(d, New Object() {text})
                Else
                   
                    Me.RichTextBox1.Text = text
                    result = text.Split(stringSeparators)
                        TextBox1.Text = result.ElementAt(4)
                        TextBox2.Text = result.ElementAt(8)
                        TextBox3.Text = result.ElementAt(12)
    
                End If
    
    
            Catch ex As Exception
            End Try
    
        End Sub
