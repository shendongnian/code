        public ActionResult LoadScenario(int bookId)
        {
          SessionProvider.SessionLoadSceanrio = true;
          // remaining code
          return Json(new {ScenarioId, SessionLoadSceanrio = SessionProvider.SessionLoadSceanrio}, JsonRequestBehavior.AllowGet);
        }
