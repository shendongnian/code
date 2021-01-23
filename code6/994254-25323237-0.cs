    Public Class AuditTrail
        Private m_Mac As String
        Public Property Mac() As String
            Get
                Return m_Mac
            End Get
            Set(ByVal value As String)
                m_Mac = value
            End Set
        End Property
        Private m_Action As Action
        Public Property Action() As Action
            Get
                Return m_Action
            End Get
            Set(ByVal value As Action)
                m_Action = value
            End Set
        End Property
        Private m_User As String
        Public Property User() As String
            Get
                Return m_User
            End Get
            Set(ByVal value As String)
                m_User= value
            End Set
        End Property
        /*Add more properties as needed*/
        Public Function Create() As String
            Dim Result As String
            Dim SqlCmdStr As String = ("INSERT INTO LaceAudit(user, action, mac) VALUES (@User, @Action, @Mac)")
            Using SqlConn As New SqlConnection(_ConnectionString)
                Using SqlCmd As New SqlCommand(SqlCmdStr, SqlConn)
                    Try
                        SqlConn.Open()
                        With SqlCmd.Parameters
                            .Clear()
                            .AddWithValue("User", User)
                            .AddWithValue("Action", Action)
                            .AddWithValue("Mac", Action)
                        End With
                        SqlCmd.ExecuteNonQuery()
                        Result = "Audit record successfully logged."
                     Catch ex As Exception
                         Result = ex.Message
                     Finally
                         SqlConn.Close()
                         SqlCmd.Dispose()
                         SqlConn.Dispose()
                     End Try
                     Return Result
                End Using
            End Using
        End Function
    End Class
