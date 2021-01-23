        //Here is my Code
         <%
                 bool HasSelectedNode = false;
    //i iterated through the overall nodes of the tree and checked any of the node is selected or not 
                 for (int i = 0; i < ApplicationTree.Nodes.Count;i++ )
                 {
                 if(ApplicationTree.Nodes[i].Selected==true)
                 {
                     HasSelectedNode = true;
                 }
                 }
                  %>
             <%if(HasSelectedNode)
               {%>                         
                            <%
              IsReviewPending = view_access.IsWaitingForViewAccess(ApplicationTree.SelectedNode.Value, Session["empCode"].ToString());
                 //  IsReviewPending = true;
              if (IsReviewPending)
              {
                  CanReviewAccess = true;
              }
              else 
              {
                  CanReviewAccess = false;
              }                    
                                      %>  
                  <%if(CanReviewAccess)
                    {%>
                <asp:Button ID="btn_Review_Access" OnClick="btn_Review_Access_Click" runat="server" BackColor="#C6304A" ForeColor="White" Text="Confirm Access Review" Width="200px"  CssClass="center3" />                 
                  <%} %>
                
                                 <%} %>
