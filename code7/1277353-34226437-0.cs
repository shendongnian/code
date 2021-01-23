        public JsonResult PersonsList(string birthyear)
        {
            using (var db = new TutorialDBContext())
            {
                IQueryable<Person> people;
                if (birthyear == "All")
                {
                    people = from m in db.persons
                        select m;
                    people = people.OrderByDescending(s => s.birthdate);
                }
                else
                {
                    var NumericYear = Convert.ToInt32(birthyear);
                    people = from m in db.persons
                        where m.birthdate.Year >= NumericYear
                        where m.birthdate.Year <= (NumericYear + 9)
                        select m;
                }
                return Json(people, JsonRequestBehavior.AllowGet);
            }
        }
