    <telerik:GridTemplateColumn>
           <ItemTemplate>
               <asp:Button ID="btnReject" runat="server" CommandName="Reject"  CommandArgument='<%# Eval("Id") %>'/>
           </ItemTemplate>
     </telerik:GridTemplateColumn>
    
    protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
       {
           if (e.CommandName == "Reject")
           {
               var Id = e.CommandArgument.ToString();
               // do something...
           }
       }
