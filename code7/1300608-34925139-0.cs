        public int AddPost(string name, string description)
        {
            var post = new Post() { Name = name, Description = description };
            if(res.Validate())
            {
                using (var db = new DbContext())
                {
                  var res = db.Posts.Add(post);
                  db.SaveChanges();
                  return res.Id;
                }
            }
            else
                return -1; //if not success
       }
    
    
        public static bool Validate(this Post post)
        {
            bool isValid=false;
            //validate post and change isValid to true if success
            if(isvalid)
                return true;
            }
            else
                return false;
        }
