    public AgendaViewModel CreateAgendaViewModel(int annee, int mois)
    {
                AgendaViewModel agendata = new AgendaViewModel();
        
                agendata.ListRDV = dal.GetListRDV(mois, annee); //Loads the list of appointments for the chosen month
                agendata.FirstDay = dal.GetFirstDay(annee, mois);
                agendata.MonthLength = dal.GetMonthLength(annee, mois);
                agendata.MonthName = dal.GetMonthName(mois) + " " + annee.ToString();
                agendata.Mois = mois;
                agendata.Annee = annee;
    
                return agendata;
    }
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
