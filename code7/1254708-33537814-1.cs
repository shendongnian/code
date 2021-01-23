     <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
                 <asp:Button runat="server" ID="btndelete" Text="Delete" CommandArgument='<%# Eval("Id") %>' CommandName="Deleterow"></asp:Button>                    
               </ItemTemplate>
          </asp:TemplateField>
    else if (e.CommandName == "Deleterow")
            {     
                SqlCommand com = new SqlCommand("StoredProcedure4", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", Convert.ToInt32(e.CommandArgument));
                var id = Int32.Parse(e.CommandArgument.ToString());                
                GridView1.Rows[id].Visible = false;
                com.ExecuteNonQuery();
                Response.Redirect("studententry.aspx");
            }                                               
