    db.Users.Add(user);
    db.SaveChanges();
    
    for (int i = 0; i < Qualifications.Count(); i++)
                {
                    qualification.AssignedUser = user.id;
                    db.Entry(qualification).State = EntityState.Modified;
                    db.SaveChangesAsync();
                }
