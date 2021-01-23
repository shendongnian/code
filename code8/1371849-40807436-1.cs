    Public Class EventRequestData
        Public Property unsubscribed As Boolean
        Public Property oKendo As CKendoGridOptions
    End Class
    ' This works
    Public Function read(data As EventRequestData) As OrmedReturnData
        Dim oReturn As New OrmedReturnData
        If IsLoggingEnabled() Then
            WriteToEventLog("Hub getevent_item called")
        End If
        Dim oToken As TokenHelper.TokenData = TokenHelper.ValidateToken(New Guid(Context.Request.Cookies("token").Value))
        If oToken.TokenOK = False Then
            oReturn.Success = False
            oReturn.ErrorMessage = ERROR_INVALID_TOKEN
        Else
            Dim oData As New EventItems
            oReturn = oData.Getevent_items(data.unsubscribed, data.oKendo)
        End If
        Return oReturn
    End Function
