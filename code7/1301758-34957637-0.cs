    protected void Button1_Click(object sender, EventArgs e)
    {
         //a list of values handled is stored in ViewState as ValuesHandled
         List<string> handledValues = new List<string>();
         if (ViewState["ValuesHandled"] != null) {
             List<string> handledValues =  (ViewState["ValuesHandled"] as List<string>;
         }
        for (int i = 1; i <= 10; i++)
        {
            string a = "A" + i.ToString();
            //check if i = 4 has had its values input successfully
            if (i == 4  && !handledValues.Contains(i.ToString()))
            {
                loop = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                handledValues.Add(i.toString());
                //break the loop since we need to return to browser for input by user
                break;
            }
            else if (i == 5  && !handledValues.Contains(i.ToString()))
            {//check if i = 5 has had its values input successfully
                loop = true;
                handledValues.Add(i.toString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                //break the loop since we need to return to browser for input by user
                break;
            }
            else
            {
                List.Add(a);
            }
        }
        //update the ViewState for ValuesHandled
       ViewState["ValuesHandled"] = handledValues;
    }
