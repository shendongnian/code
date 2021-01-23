    Public Shared Sub ErrorMsg(ErrMsg As String)
        Dim myPage = TryCast(HttpContext.Current.Handler, Page)
        If myPage IsNot Nothing Then
            Dim master = myPage.Master
            Dim myMaster = TryCast(master.Master, TopMaster)
            While master.Master IsNot Nothing AndAlso myMaster Is Nothing
                master = master.Master
                myMaster = TryCast(master, TopMaster)
            End While
            myMaster.litMsg.Text = ErrMsg
        End If
    End Sub
