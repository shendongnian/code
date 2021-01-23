    <asp:Button ID="txtResetbtn" runat="server" OnClick="txtResetbtn_Click" />
    
    protected void txtResetbtn_Click(object sender, EventArgs e)
        {
          TextBox1.Text = string.Empty;
        }
