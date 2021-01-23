        protected void GridView_PreRender(object sender, EventArgs e)
        {
            if(!admin())
            {
               GridViewId.Columns[5].Visible = true;
            }
            else
            {
               //do something
            }            
        }
