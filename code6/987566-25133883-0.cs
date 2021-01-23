    ....
    <UpdatePanel ID="main" UpdateMode="Conditional">
        <ContentTemplate>
        ....
            <asp:TextBox ID="txtEndDate" runat="server" ReadOnly="true"></asp:TextBox>
            <asp:ImageButton ID="imgEndDate" ... />
            <asp:Panel ID="pnlEndCalendar" runat="server" ...>
                <UpdatePanel runat="server">
                    <ContentTemplate>                
                        <asp:Calendar ID="calEndDate" runat="server"
                                      OnSelectionChanged="calEndDate_SelectionChanged" ...>
                            ....
                        </asp:Calendar>
                    </ContentTemplate>
                </UpdatePanel>
            </asp:Panel>
            <ajax:ModalPopupExtender ID="ModalPopupExtenderEndDate" runat="server" TargetControlID="imgEndDate" PopupControlID="pnlEndCalendar" ...>
                    </ajax:ModalPopupExtender>
        ....
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="cal" EventName="selectionchanged" />
        </Triggers>
    </UpdatePanel>
