    public List<Member> Search(string name, string email, string telephone, string username, List<Member> source)
        {
            var query = from s in source
                        where (((s.name == name) || string.IsNullOrEmpty(name))
                            && ((s.email == email) || string.IsNullOrEmpty(email))
                            && ((s.telephone == telephone) || string.IsNullOrEmpty(telephone))
                            && ((s.username == username) || string.IsNullOrEmpty(username)))
                        select s;
            return query.ToList();
        }
        public class Member
        {
            public String username;
            public String name;
            public String email;
            public String telephone;
        }
