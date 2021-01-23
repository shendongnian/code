    <%@page codepage="65001" language="C#" lcid="6153"%>
    <%@ Import namespace="ConnectorBuilder.SetAuthenticator" %>
    <script language="c#" runat="server">
        public class MyAuthenticator:IAuthenticator
        {
            public Task<IUser> AuthenticateAsync(ICommandRequest commandRequest,CancellationToken cancellationToken)
            {
                return Task.FromResult((IUser)new User(true,"editor"));
            }
        }
    </script>
