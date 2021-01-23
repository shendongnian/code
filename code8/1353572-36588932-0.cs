     private List<Student> students;
    
            public List<Student> Collection()
            {
                students = new List<Student>
        {
            new Student {Id = 1, Name = "Name1"},
            new Student {Id = 2, Name = "Name2"},
            new Student {Id = 3, Name = "Name3"},
        };
                return students;
            }
            protected void Page_Load(object sender, EventArgs e)
            {
                List<Student> students = Collection();
               // ViewState["students"] = students;
                HttpCookie myCookie = new HttpCookie("MyTestCookie");
                DateTime now = DateTime.Now;
                JavaScriptSerializer serializer=new JavaScriptSerializer();
                var data = serializer.Serialize(students);
                // Set the cookie value.
                myCookie.Value = data;
                // Set the cookie expiration date.
                myCookie.Expires = now.AddHours(1);
    
                // Add the cookie.
                Response.Cookies.Add(myCookie);
    
                //Response.Write("<p> The cookie has been written.");
            }
