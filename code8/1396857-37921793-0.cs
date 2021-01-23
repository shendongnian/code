     protected void Button1_Click(object sender, EventArgs e)
        {
            List<string> results = Get_Rand_Values();
            Get_CheckList(results);
            Session["results"] = results;
        }
      protected void buttonCount_Click(object sender, EventArgs e)
        {
            int i = 0;
            //foreach (Control c in )
            //{
            //    if ((c is CheckBox) && ((CheckBox)c).Checked)
            //    {
            //        ++i;
            //    }
            //}
            var results = (List<string>)Session["results"];
            foreach (var k in results)
            {
                var tmp = Request[Cypher_MD5(k)];
                if(tmp  == "on")
                {
                    i++;
                }
                count++;
            }
            Response.Write("<script>alert('Checked: " + i + "');</script>");
        }
