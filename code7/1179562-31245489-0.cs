     protected void btnAdd_Click(object sender, EventArgs e)
        {
            Session["tempAdd"] = output.Text;
            output.Text = String.Empty;
        }
        
        protected void proc_Click(object sender, EventArgs e)
        {
            temp = Convert.ToDouble(output.Text);
            string oldval=Session["tempAdd"] != null ?Session["tempAdd"].ToString() :"";
             if(oldval!="")
              tempadd=Convert.ToDouble(oldval);
                                               
            calc = tempAdd + temp;
            output.Text = calc.ToString();
        }
