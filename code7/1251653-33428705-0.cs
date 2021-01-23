     <asp:UpdatePanel ID="updt" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False" >
            <ContentTemplate>
              <.......Put Your Display Text Boxes Here .........>
              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
                   DataKeyNames="ID" DataSourceID="SqlDataSource1">
                   ..................
              </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
            </Triggers>       
        </asp:UpdatePanel>   
