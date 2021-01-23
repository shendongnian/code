    public static void getSearchResultsString()
        {
            string[] userList = { "user1", "user2", "user3" };
            var json = "";
            List<ADUser> users = new List<ADUser>();
            foreach (string user in userList)
            {
                string userName = "jsmith";
                string email = "jsmith@example.com";
                string createdDate = "3/20/2016";
                ADUser aduser = new ADUser(userName, email, createdDate);
                users.Add(aduser);
            }
            json = new JavaScriptSerializer().
                Serialize(new { users = users });
            Response.Write(json);
        }
