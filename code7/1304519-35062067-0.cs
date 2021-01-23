    <asp:GridView ID="GridView1" runat="server" ItemType="Business.Models.Printer" SelectMethod="SelectPrinters" Style="margin-left: 30px" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="PrinterID" HeaderText="Id"/>
            <asp:TemplateField HeaderText="Resolution">
                <ItemTemplate>
                    <asp:DataList ID="Resolutions"
                        RepeatDirection="Horizontal"
                        RepeatLayout="Table"
                        RepeatColumns="0" runat="server" ItemType="Business.Models.Resolution" DataKeyNames="ResolutionID" DataSource='<%# Item.Resolutions %>' >
                        <ItemTemplate>
                            <asp:Label ID="lblResolutions" runat="server"> <%#Item.Resolution.Measure %></asp:Label>
                        </ItemTemplate>
                        <SeparatorTemplate>
                            ,
                        </SeparatorTemplate>
                    </asp:DataList>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
