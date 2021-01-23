    Private Sub _SqlConnection_InfoMessage(sender As Object, e As System.Data.SqlClient.SqlInfoMessageEventArgs) Handles _SqlConnection.InfoMessage
        If _BackupInProgress Then
            If e.Errors.Count > 0 Then
                For Each sqlError As SqlError In e.Errors
                    If sqlError.Number = 3211 Then
                        Dim rxPercentageDone = New Regex("(\d*)")
                        Dim match = rxPercentageDone.Match(sqlError.Message)
                        If match.Success Then
                            ' match.Groups(1).Value holds the actual progress value
                            Debug.Print(e.Message)
                        End If
                    End If
                Next
            End If
        End If
    End Sub
