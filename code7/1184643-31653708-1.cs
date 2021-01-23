     public ActionResult GetThreatControls(int ThreatID)
            {
                RiskAssessmentApplicationEntities _DBContext = new RiskAssessmentApplicationEntities();
                ThreatHasControl ViewModel = new ThreatHasControl();
                ViewModel.Threat = _DBContext.Threats.Single(x => x.ID == ThreatID);
                ViewModel.Controls = _DBContext
                                            .ThreatHasControl
                                            .Include("ThreatHasControl.Control")
                                            .Where(x => x.ThreatID == ThreatID)
                                            .Select(x => x.Control);
    
                return View(ViewModel);                                   
            }
