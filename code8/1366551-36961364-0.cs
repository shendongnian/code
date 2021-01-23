     public ActionResult GetPersonAgeAvg()
            {
                var avg = ope.AgeAverage();
                IEnumerable<Person> pers = db.People.ToList();
                var tuple = new Tuple<IEnumerable<Person>, PersonAgeAvg>(pers, avg);
                return View(tuple);
            }
