        Private Sub CreateAuthorisationCookie(ByVal Role As String)
        ' Create and tuck away the cookie
        Dim authTicket As New FormsAuthenticationTicket(1, txtUsername.Text, _
                                                        DateTime.Now, _
                                                        DateTime.Now.AddMinutes(15), False, Role, FormsAuthentication.FormsCookiePath)
        Dim encTicket As String = FormsAuthentication.Encrypt(authTicket)
        Dim faCookie As New HttpCookie(FormsAuthentication.FormsCookieName, encTicket)
        Response.Cookies.Add(faCookie)
    End Sub
