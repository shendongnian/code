     [ResponseType(typeof(UserModel))]
        public IHttpActionResult Get(string id)
        {
            var user = db.AspNetUsers.Include(a=>a.AspNetRoles).Where(s => s.UserName == id).FirstOrDefault();
            if (user == null)
                return NotFound();
            var data = new UserModel
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Roles = user.AspNetRoles.Select(s => s.Name).ToArray()
                //...other properties you want to return
            };
            return Ok(data);
        }
        public class UserModel
        {
            public string UserName { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string[] Roles { get; set; }
        }
