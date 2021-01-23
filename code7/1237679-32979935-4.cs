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
