        <%Post p = new Post();
          List<Post> lp = new List<Post>();
          for (int i = 0; i < lp.Count; i++)
          {
              hdnTempID.Value = lp[i].postID; //save postID
              %>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="Button" onclick="Button1_Click"  CommandArgument='<%# lp[i].postID %>'/>  //Save the value of postID in command argument 
    <asp:HiddenField ID="hdnTempID" runat="server" />
              <%
          } %>
