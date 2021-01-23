    <telerik:RadGrid ID="GridMain" runat="server" Skin="Default" ShowHeader="false" OnNeedDataSource="GridMain_NeedDataSource"
                BorderStyle="None" Width="500px">
                <MasterTableView>
                    <ItemTemplate>
                        <telerik:RadGrid ID="RadGrid1" runat="server" OnNeedDataSource="RadGrid1_NeedDataSource"
                            Skin="Vista">
                            <MasterTableView AutoGenerateColumns="false">
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="ID" UniqueName="ID" DataField="ID" />
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                        <telerik:RadGrid ID="RadGrid2" runat="server" OnNeedDataSource="RadGrid2_NeedDataSource"
                            Skin="Vista">
                            <MasterTableView AutoGenerateColumns="false">
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="Description" UniqueName="Description" DataField="Description" />
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </ItemTemplate>
                </MasterTableView>
            </telerik:RadGrid>
