    <asp:UpdatePanel ID="pnlParent" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:UpdatePanel ID="upGenTaskCli" runat="server" UpdateMode="Conditional" ClientIDMode="Static">
                <ContentTemplate>
                    Client: <asp:Label ID="lblCli" ClientIDMode="Static" runat="server" Text=""></asp:Label>
                    <br />
                    Onboarding Date: <asp:Label ID="lblCliDate" ClientIDMode="Static" runat="server" Text=""></asp:Label>
                    <br />
                    Contact Information: <asp:Label ID="lblCliCont" ClientIDMode="Static" runat="server" Text=""></asp:Label>
                    <br />
                    Notes: <asp:Label ID="lblCliNotes" runat="server" ClientIDMode="Static" Text=""></asp:Label>
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
    </contentTemplate>
    </updatePanel>
