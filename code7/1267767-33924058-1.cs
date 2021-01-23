            string stuff =
    @"adamsmith
    Adam Smith
    B1u2d3a4
    STUDENT
    marywilson
    Mary Wilson
    s1Zeged
    TEACHER
    sz12gee3
    George Johnson
    George1234
    STUDENT
    sophieb
    Sophie Black
    SophieB12
    STUDENT";
        public void Main(string[] args)
        {
            string line;
            var users = new List<User>();
            using (var sr = new StringReader(stuff))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    User user = new User();
                    user.ID = line;
                    user.Name = sr.ReadLine();
                    user.PW = sr.ReadLine();
                    user.teacher = sr.ReadLine() == "TEACHER";
                    users.Add(user);
                }
            }
        }
