     <table style="width:100%; margin-left:auto; margin-right:auto;" id="tblTst" runat="server">
            <tr>
                <td>
                    <h2>
                        Vehicle Information
                        <asp:Label ID="lblTest" Text="THis is a Test" ForeColor="Salmon" runat="server" />
                        <asp:Button ID="btnTest" CommandArgument="0" OnClick="btnTest_click" runat="server" Text="Test" />
                    </h2>
                </td>
            </tr>
            <tr>
                <td>
                        <asp:Label ID="lblTst2" Text="This is also a Test" ForeColor="Salmon" runat="server" />
                        <asp:Button ID="btnTest2" CommandArgument="1" OnClick="btnTest_click" runat="server" Text="Test" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMsg" runat="server" />
                </td>
            </tr>
        </table>
        protected void btnTest_click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        string comment = "";
        string editField = "";
        if (btn != null)
        {
            editField = btn.ID.Replace("btn", "");
            btn.Visible = false;
            //Getting and storing rowindex
            foreach(HtmlTableCell cl in tblTst.Rows[Convert.ToInt32(btn.CommandArgument)].Cells)
            {
                foreach (Control ctrl in cl.Controls)
                {
                    if(ctrl is Label)
                    {
                        Label txt = new Label();
                        txt = ctrl as Label;
                        txt.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFB2");
                        txt.Focus();
                        comment = txt.Text;
                        lblMsg.Text = comment;
                        return;
                    }
                }
            }
            //Further methods unnecessary for this question
        }
    }
