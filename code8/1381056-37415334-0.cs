    <%@page codepage="65001" debug="true" lcid="6153"%>
    <%@import namespace="System.Linq"%>
    <%@import namespace="System.Threading"%>
    <%@import namespace="System.Threading.Tasks"%>
    <%@import namespace="CKSource.CKFinder.Connector.Core"%>
    <%@import namespace="CKSource.CKFinder.Connector.Core.Authentication"%>
    <script language="c#" runat="server">
    public class MyAuthenticator:IAuthenticator{
    	public Task<IUser> AuthenticateAsync(ICommandRequest commandRequest,CancellationToken cancellationToken){
    		return Task.FromResult((IUser)new User(true,"editor"));
    	}
    }
    </script>
