    <div id="contentarea">
                <p> Search Employee ID, Training Code, Contract Number<br/>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>Contract Number</asp:ListItem>
                        <asp:ListItem>Training Code</asp:ListItem>
                        <asp:ListItem>Employee ID</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="searchText" runat="server" Height="16px" Width="146px"></asp:TextBox>
                    <asp:Button ID="ButtonSearch" runat="server" Text="Search" OnClick="ButtonSearch_Click" />
                    <asp:Button ID="ButtonClear" runat="server" Text="Clear" OnClick="ButtonClear_Click" />
                </p>
                
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
