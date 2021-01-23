       Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
            ' Fires upon attempting to authenticate the use
            ' Get the authentication cookie
            Dim cookieName As String = FormsAuthentication.FormsCookieName
            Dim authCookie As HttpCookie = Context.Request.Cookies(cookieName)
    
            ' If the cookie can't be found, don't issue the ticket
            If authCookie Is Nothing Then
                Return
            End If
    
            ' Get the authentication ticket and rebuild the principal 
            ' & identity
            Dim authTicket As FormsAuthenticationTicket = FormsAuthentication.Decrypt(authCookie.Value)
            Dim roles As String() = authTicket.UserData.Split(New [Char]() {"|"c})
            Dim userIdentity As New GenericIdentity(authTicket.Name)
            Dim userPrincipal As New GenericPrincipal(userIdentity, roles)
            Context.User = userPrincipal
        End Sub
      Private Sub Global_asax_PostAuthenticateRequest(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PostAuthenticateRequest
            ' Get a reference to the current User
    
            Dim usr As IPrincipal = HttpContext.Current.User
    
            ' If we are dealing with an authenticated forms authentication request
    
            If usr.Identity.IsAuthenticated AndAlso usr.Identity.AuthenticationType = "Forms" Then
    
    
                Dim fIdent As FormsIdentity = TryCast(usr.Identity, FormsIdentity)
    
                ' Create a CustomIdentity based on the FormsAuthenticationTicket  
    
                Dim ci As New CCustomIdentity(fIdent.Ticket)
    
                ' Create the CustomPrincipal
    
                Dim p As New CCustomPrincipal(ci)
    
                ' Attach the CustomPrincipal to HttpContext.User and Thread.CurrentPrincipal
    
                HttpContext.Current.User = p
    
    
                Threading.Thread.CurrentPrincipal = p
            End If
        End Sub
