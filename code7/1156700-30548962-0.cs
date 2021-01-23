        [ChildActionOnly]
        public ActionResult TeamAssignment()
        {
            // Instantiate A VIEW MODEL HERE TO PASS INTO THE PARTIALVIEW
            MyCustomModel model = new MyCustomModel();
            model.nameList = (from p in db.Participant
                where p.ParticipantType == "I"
                select new {
                    p.ParticipantID,
                    p.IndividualName
                }).ToList();
            model.teamList = (from p in db.Participant
                where p.ParticipantType == "T"
                select new {
                    p.ParticipantID,
                    p.TeamName
                }).ToList();
            return PartialView("TeamAssignment", model);
        }
