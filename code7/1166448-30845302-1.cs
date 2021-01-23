        protected void Button1_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(((Button)sender).CommandArgument); // get saved ID from command argument
            Responses p = new Responses();
            Cubers c = new Cubers();
            p.InsertResponseUser("Admin", int.Parse(Id), "xxxxx", DateTime.Now);
            //method add response to post by username,id post, description,date time ;
        }
