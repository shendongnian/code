    Try this:
       >asp:ScriptManager runat="server">
         >/asp:ScriptManager>
            >asp:UpdatePanel ID="UpdatePanel1" runat="server">
             >ContentTemplate>
                 >asp:ListBox ID="ListBox1" runat="server"  onselectedindexchanged="ListBox1_SelectedIndexChanged" AutoPostBack="True">
                    >asp:ListItem Value="0">Item1</asp:ListItem>
                    >asp:ListItem Value="1">Item2</asp:ListItem>
                    >asp:ListItem Value="2">Item3</asp:ListItem>
                 >/asp:ListBox>
            >/ContentTemplate>
            >/asp:UpdatePanel>
           
        >br />
    
        >asp:Label ID="lblTB" runat="server"/>
    i dont even see any wrong just add scriptmanager.
     Copy this one to your Code behind it should work.
       try
            { 
                  HttpCookie getcook = Request.Cookies["saveme"];
                  string check = getcook["saveme"].ToString();
                  if (getcook["saveme"].Length > 0 &&      getcook["saveme"].ToString()!="none")
                    {
                        lblTB.Text = getcook["saveme"].ToString();
                    }
            }
            catch(Exception er)
            {
                HttpCookie cookie = new HttpCookie("saveme");
                cookie["saveme"] = "none";
                Response.Cookies.Add(cookie);
            }
          
        }
        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTB.Text = "You choose: " + ListBox1.SelectedItem.Text;
            HttpCookie setcook =Request.Cookies["saveme"];
            setcook["saveme"] = lblTB.Text;
            setcook.Expires = DateTime.Now.AddDays(1d); ;
            Response.Cookies.Add(setcook);
            Response.Redirect("updatepanelhere.aspx", false);
        }
