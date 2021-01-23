    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
            {
                string hidd1 = ((HiddenField)(e.Item.FindControl("hidd1"))).Value; // find hidden field
                Label l1 = (Label)(e.Item.FindControl("Label4"));// find lable4 value
                Label l2 = (Label)(e.Item.FindControl("Label4"));//// find lable5 value
                if (hidd1.ToLower == "s")// your conditon
                {
                    l1.Visible = true;// your code1
                    l2.Visible = true;
                }
               else if (hidd1.ToLower == "h")
                {
                    l1.Visible = false;// your code2
                    l2.Visible = false;
                }
               else
                {
                    // defalut
                }
            }
