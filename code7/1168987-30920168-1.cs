    [HttpPost]
        public ActionResult EditUserTicket(Guid id, string Note)
        {
            if (Note != "")
            {
                AddTicketNote(Guid.Parse(Session["LoggedUserID"] as string), id, Note, true);  
            }
            TempData["NoteError"] = true;
            return RedirectToAction("EditUserTicket", id);
        }
