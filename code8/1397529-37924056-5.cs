    public ActionResult Fill(string fullName)
            {
                ContactPerson contactPerson = new ContactPerson();
                if (fullName == "Richard Hendricks") //Replace this with call to the database in order to get your contact info
                {
                    contactPerson = new ContactPerson
                    {
                        FullName = "Richard Hendricks",
                        Email = "r.hendricks@piedpiper.com"
                    };
                }
                else if (fullName == "Erlich Bachman")
                {
                    contactPerson = new ContactPerson
                    {
                        FullName = "Erlich Bachman",
                        Email = "e.bachman@piedpiper.com"
                    };
                }
                return Json(contactPerson, JsonRequestBehavior.AllowGet);
            }
