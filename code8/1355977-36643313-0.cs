    public JsonResult UnicityUserId(string UserId, string ID)
    {
        int id = 0;
        Int32.TryParse(ID, out id);
        bool ok = false;
        if (!String.IsNullOrEmpty(UserId))
            ok = !UserDb.Exist(this.db, this.Tracer, UserDb.UserId, UserId, id); //Checks wether there is already another user with the same UserId
        return (Json(ok, JsonRequestBehavior.AllowGet));
    }
