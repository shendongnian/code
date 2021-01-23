            try
            {
                var rpmuser = db.rpm_usr.Single(z => z.usr_id == "MillXZ");
                rpmuser.usr_pwd = hash;
                rpmuser.salt = salt;
    
                db.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
    
            
