        int doWhat;
        protected void Page_Load(object sender, EventArgs e)
        {
            //doWhat = Convert.ToUInt16(ViewState["doWhat"]);
            doWhat = Convert.ToUInt16(HiddenField1.Value);
            if (doWhat == 1)
            {
                // code to dynamically load group 1 controls
            }
            else
            {
                // code to dynamically load group 2 controls
            }
            Label1.Text = Convert.ToString(doWhat);
        }
        protected void Button_Click(object sender, EventArgs e)
        {
            //Do Nothing
            //Button btn = sender as Button;
            //if (btn.ID == "Button1")
            //{
            //    doWhat = 1;
            //}
            //else
            //{
            //    doWhat = 2;
            //}
            //ViewState.Add("doWhat", doWhat); 
        }
