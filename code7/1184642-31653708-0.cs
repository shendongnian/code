     public ActionResult GetThreatControls(int ThreatID)
            {
                RiskAssessmentApplicationEntities _DBContext = new RiskAssessmentApplicationEntities();
                ThreatHasControl ViewModel = new ThreatHasContro();
                ViewModel.Threat = _DBContext.Threats.Single(x => x.ID == ThreatID);
                ViewModel.SecurityEvents = _DBContext
                                            .ThreatHasSecurityEvents
                                            .Include("ThreatHasSecurityEvent.SecurityEvent")
                                            .Where(x => x.ThreatID == ThreatID)
                                            .Select(x => x.SecurityEvent);
    
                return View(ViewModel);                                   
            }
