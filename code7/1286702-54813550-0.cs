    <div class="menuicon">
                        <asp:ImageButton ID="menubtn" ImageUrl="~/assets/menu.png" OnClick="menubtn_Click" runat="server" />
                        <asp:HiddenField ID="hdfMenuStatus" runat="server" Value="menudown" />
                    </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="menulist">
                        <asp:Panel ID="panMenuContainer" runat="server">
                            <ul>
                                <li>
                                    <a href="UserAuthentication">Login</a>
                                </li>
                            </ul>
                        </asp:Panel>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="menubtn" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
