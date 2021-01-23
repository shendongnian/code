    public ActionResult Index(int annee = 0, int mois = 0)
    {
            DateTime date = DateTime.Now;
            if(annee == 0) annee = date.Year; // if not set initialize with default year
            if(mois == 0)  mois = date.Month; // if not set initialize with default month
            AgendaViewModel Agendata = new AgendaViewModel();
    
            Agendata.ListRDV = dal.GetListRDV(mois, annee); //Loads the list of appointments for the chosen month
            Agendata.FirstDay = dal.GetFirstDay(annee, mois);
            Agendata.MonthLength = dal.GetMonthLength(annee, mois);
            Agendata.MonthName = dal.GetMonthName(mois) + " " + annee.ToString();
            Agendata.Mois = mois;
            Agendata.Annee = annee;
            if (dal.GetFirstDay(annee, mois) == 0)
            {
                return View("Error");
            }
            return View(Agendata); 
        }
