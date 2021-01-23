                GOVBONDINTERESTSCHEDULE editmodel = new GOVBONDINTERESTSCHEDULE();
                editmodel = new Entities(Session["Connection"] as EntityConnection).GOVBONDINTERESTSCHEDULEs.Include("BOND").AsNoTracking().Where(t => t.REFERENCE == Ref).SingleOrDefault();
                editmodel.STATUS = ConstantVariable.STATUS_APPROVED;
                editmodel.LASTUPDATED = DateTime.Now;
                editmodel.LASTUPDATEDBY = Session["UserId"].ToString();
                using (Entities db = new Entities(Session["Connection"] as EntityConnection))
                {
                    db.Entry(editmodel).State = EntityState.Modified;
                    db.SaveChanges();
                }
