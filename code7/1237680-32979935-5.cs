    public ActionResult Index(int annee = 0, int mois = 0)
    {
            DateTime date = DateTime.Now;
            if(annee == 0) annee = date.Year; // if not set initialize with default year
            if(mois == 0)  mois = date.Month; // if not set initialize with default month
    
            AgendaViewModel Agendata = CreateAgendaViewModel(annee, mois);
            if (dal.GetFirstDay(annee, mois) == 0)
            {
                return View("Error");
            }
            return View(Agendata); 
        }
