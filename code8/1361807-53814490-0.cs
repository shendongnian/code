    public void UpdateSecurityStamp(string userId)
            {
                using (var db = new ApplicationDbContext())
                {
                    var user = db.Users.FirstOrDefault(x => x.Id.Equals(userId));
                    if (user != null)
                    {
                        user.SecurityStamp = Convert.ToString(Guid.NewGuid());
                        db.SaveChanges();
                    }
                }
            }
