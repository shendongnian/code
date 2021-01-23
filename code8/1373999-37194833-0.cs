        protected void redirectTimer_Tick(object sender, EventArgs e)
        {
            if(someConditionIsSatisfied)
            {
                Response.Redirect(myUri, false);
            }
        }
