        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
            {
                string hidd1 = ((HiddenField)(e.Item.FindControl("hidd1"))).Value; // find hidden field
                Label l1 = (Label)(e.Item.FindControl("Label4"));// find lable4 value
                Label l2 = (Label)(e.Item.FindControl("Label4"));//// find lable5 value
                if ()// your conditon
                {
                    l1.Visible = false;// your code1
                }
               else if ()
                {
                    l1.Visible = false;// your code2
                }
               else
                {
                    // defalut
                }
            }
