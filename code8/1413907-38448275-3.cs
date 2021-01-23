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
