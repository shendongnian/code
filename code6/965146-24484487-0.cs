    public class MyFriends
        {
            public long uid { get; set; }
            public string username { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public long? friend_count { get; set; }  //nullable
            public string pic_big { get; set; }
            public string birthday { get; set; }
            public string birthday_date { get; set; }
            public string contact_email { get; set; }
        }
    protected void friendsList()
    {
        var fb = new FacebookClient("YOUR TOKEN HERE");
        var query = string.Format(@"SELECT uid, username, first_name, last_name, friend_count, pic_big, birthday, birthday_date, contact_email 
                            FROM user WHERE uid IN (SELECT uid2 FROM friend WHERE uid1 = me())");
        dynamic parameters = new ExpandoObject();
        parameters.q = query;
        dynamic results = fb.Get("/fql", parameters);
        List<MyFriends> q = JsonConvert.DeserializeObject<List<MyFriends>>(results.data.ToString());
        
        GridView1.DataSource = q;
        GridView1.DataBind();
    }
