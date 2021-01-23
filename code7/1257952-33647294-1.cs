      private void RefreshOldDossierFinancement(long dfId)
        {
            TotalContrats = 0.000M;
            TotalMefs = 0.000M;
            TotalCommandes = 0.000M;
            decimal phb = 0.000M;
            decimal pctr = 0.000M;
            decimal pmef = 0.000M;
            PercentageHorsBilan = "(0%)";
            PercentageContrats = "(0%)";
            PercentageMef = "(0%)";
            DossierNumber = "";
            using (UnitOfWork cx = new UnitOfWork(_currentLog))
            {
                try
                {
                    IDossierFinancementRepository sr = new DossierFinancementRepository(cx, _currentLog);
                    IDossierFinancementManagementService dfms = new DossierFinancementManagementService(_currentLog, sr);
                    IDataTraceRepository dtr = new DataTraceRepository(cx, _currentLog);
                    IDataTraceManagementService dtms = new DataTraceManagementService(_currentLog, dtr);
                    CurrentDossierFinancement = dfms.FindById(dfId);
                    /*if (CurrentDossierFinancement == null) //Not Found
                        Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Dossier Financement n° " + dfId.ToString() + " introuvable."),"DossierFinancementError");
                    else*/
                    {
                        DossierFinancementEnteredKey = CurrentDossierFinancement.DossierId;
                        DossierNumber = "N° " + DossierFinancementEnteredKey.ToString();
                        RequestNature = (CurrentDossierFinancement.InvestmentGoal == 0) ? "Création" : (CurrentDossierFinancement.InvestmentGoal == 1) ? "Renouvellement" : "Extension";
                        EtatDossier = (CurrentDossierFinancement.Status == 1) ? "En cours" : (CurrentDossierFinancement.Status == 2) ? "Approuvé" : "Rejeté";
                        if (CurrentDossierFinancement.ClientId != null)
                        {
                            CustomerCode = (long)CurrentDossierFinancement.ClientId;
                            CustomerName = CurrentDossierFinancement.Client.NomCli;
                        }
                        else
                        {
                            CustomerCode = 0;
                            if (CurrentDossierFinancement.ClientType == 1)
                                CustomerName = CurrentDossierFinancement.Name + " " + CurrentDossierFinancement.FirstName;
                            else
                                CustomerName = CurrentDossierFinancement.CompanyName;
                        }
                        if (CurrentDossierFinancement.Contrat != null)
                        {
                            TotalContrats = CurrentDossierFinancement.Contrat.Montant;
                            TotalHorsBilan = CurrentDossierFinancement.Contrat.Montant;
                            pctr = Math.Round((TotalContrats / CurrentDossierFinancement.Montant) * 100, 0);
                            PercentageContrats = "(" + pctr.ToString() + "%)";
                            if (CurrentDossierFinancement.Contrat.Mefs != null)
                            {
                                TotalMefs = CurrentDossierFinancement.Contrat.Mefs.Sum(x => x.Montant);
                                pmef = Math.Round((TotalMefs / CurrentDossierFinancement.Montant) * 100, 0);
                                PercentageMef = "(" + pmef.ToString() + "%)";
                            }
                            TotalHorsBilan = TotalContrats - TotalMefs;
                            phb = Math.Round((TotalHorsBilan / CurrentDossierFinancement.Montant) * 100, 0);
                            PercentageHorsBilan = "(" + phb.ToString() + "%)";
                        }
                        //Extraire la trace
                        List<DataTrace> traceList = dtms.GetTrace(DossierFinancementEnteredKey, "DossierFinancement").ToList();
                        DataTrace newRecord = traceList.Where(xx => string.Equals(xx.ActionLib, "New", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                        if (newRecord != null)
                        {
                            CreatedBy = newRecord.Coduser;
                            CreatedAt = newRecord.ActionDate.ToString();
                        }
                    }
                }
                   
                catch (Exception ex)
                {
    //Here i send a message to Window to display The Exception Message in a  custom Dialog
                    Messenger.Default.Send(new ExceptionMessageRefresh(ex), "DossierFinancement");
                }
            }
        }
