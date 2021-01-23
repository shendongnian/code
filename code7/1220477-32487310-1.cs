    try
    {
        db.SaveChanges();
    }
    except (DbEntityValidationException)
    {
        Danger("Oh Snap! Looks like something went wrong!", true);
        return View(model);
    }
