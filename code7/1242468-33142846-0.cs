    <asp:GridView ID="CRFormGridView" runat="server" AutoGenerateColumns="false"
                    OnRowDataBound="CRFormGridView_RowDataBound" AllowPaging="true" PageSize="25" ClientIDMode="Static" OnDataBound="CRFormGridView_DataBound">
    
                    <Columns>
                        <asp:BoundField DataField="CRListID" HeaderText="CR List ID" Visible="false" />
                        <asp:TemplateField HeaderText="Change Type">
                            <ItemTemplate>
                                <asp:UpdatePanel ID="updtpnlChangeType" runat="server" ClientIDMode="Static" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:DropDownList Width="150" runat="server" ID="ddlChangeType" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="ddlChangeType_SelectedIndexChanged">
                                            <asp:ListItem Text="" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Update Offer" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Add Component" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Cancel Component" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Update Request" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Add Request" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="Cancel Request" Value="6"></asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ItemTemplate>
                        </asp:TemplateField>
    
                        <asp:TemplateField HeaderText="Change Sub Type">
                            <ItemTemplate>
                                <asp:UpdatePanel ID="updtpnlChangeSubType" runat="server" ClientIDMode="Static" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:DropDownList Width="150" runat="server" ID="ddlChangeSubType" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="ddlChangeSubType_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ItemTemplate>
                        </asp:TemplateField>
    
                        <asp:TemplateField HeaderText="Request/Comments">
                            <ItemTemplate>
                                <asp:UpdatePanel ID="updtpnlDynamicControl" runat="server" ClientIDMode="Static" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:PlaceHolder ID="placehldrDynamicCnrtl" runat="server" ClientIDMode="Static" OnPreRender="placehldrDynamicCnrtl_PreRender"></asp:PlaceHolder>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
