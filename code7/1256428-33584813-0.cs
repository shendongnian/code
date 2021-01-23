    System.Web.Compilation.ParseException
    Expecting </asp:TextBox> System.Web.UI.WebControls.TextBoxControlBuilder
    
    Description: Error parsing a resource required to service this request. Review your source file and modify it to fix this error.
    Details: Expecting </asp:TextBox> System.Web.UI.WebControls.TextBoxControlBuilder
    Error origin: Parser
    Error source file: /Users/administrator/Documents/Code/Xamarin/aspnet/aspnet/Default.aspx
    Exception stack trace:
       at System.Web.Compilation.AspGenerator.Parse (System.IO.TextReader reader, System.String filename, Boolean doInitParser) in /private/tmp/source-mono-mac-4.2.0-branch/bockbuild-mono-4.2.0-branch/profiles/mono-mac-xamarin/build-root/mono-4.2.1/mcs/class/System.Web/System.Web.Compilation/AspGenerator.cs:line 627
       at System.Web.Compilation.GenericBuildProvider`1[TParser].Parse () in /private/tmp/source-mono-mac-4.2.0-branch/bockbuild-mono-4.2.0-branch/profiles/mono-mac-xamarin/build-root/mono-4.2.1/mcs/class/System.Web/System.Web.Compilation/GenericBuildProvider.cs:line 87
       at System.Web.Compilation.GenericBuildProvider`1[TParser].GenerateCode () in /private/tmp/source-mono-mac-4.2.0-branch/bockbuild-mono-4.2.0-branch/profiles/mono-mac-xamarin/build-root/mono-4.2.1/mcs/class/System.Web/System.Web.Compilation/GenericBuildProvider.cs:line 102
       at System.Web.Compilation.GenericBuildProvider`1[TParser].GenerateCode (System.Web.Compilation.AssemblyBuilder assemblyBuilder) in /private/tmp/source-mono-mac-4.2.0-branch/bockbuild-mono-4.2.0-branch/profiles/mono-mac-xamarin/build-root/mono-4.2.1/mcs/class/System.Web/System.Web.Compilation/GenericBuildProvider.cs:line 121
       at System.Web.Compilation.BuildManager.GenerateAssembly (System.Web.Compilation.AssemblyBuilder abuilder, System.Web.Compilation.BuildProviderGroup group, System.Web.VirtualPath vp, Boolean debug) in /private/tmp/source-mono-mac-4.2.0-branch/bockbuild-mono-4.2.0-branch/profiles/mono-mac-xamarin/build-root/mono-4.2.1/mcs/class/System.Web/System.Web.Compilation/BuildManager.cs:line 778
    Error source context:
    Error lines: 11, 11
    9: 		<asp:Button id="button1" runat="server" Text="Click me!" OnClick="button1Clicked" />
    10: 		<asp:TextBox id="usernameTXT" runat="server" CssClass="control">foobar</asp:TextBox>
    11: 		<asp:TextBox id="userneTXT" runat="server" CssClass="control">foobar</asp:TextBoxz>
    12: 	</form>
    13: </body>
