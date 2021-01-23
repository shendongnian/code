    foreach (ContactResponse cr in lstContactResponse)
        {
        ContactResponseRecord crr = new ContactResponseRecord() { 
                                                    ContactId = cr.ContactId,   
                                                    ActivityDate = cr.ResponseDate,   
                                                    LinkClicked = cr.Referrer};
                
         var vJourneyNodeData = from x in lstJourneyNodeData where x.Id == cr.GrandparentId select x;
         if(null != vJourneyNodeData && vJourneyNodeData.Count() > 0)
                {
                    jnd = vJourneyNodeData.FirstOrDefault();
                    crr.CampaignWaveId = "J" + jnd.Id;
                    crr.WaveDescription = jnd.Label;
                }
         var vJourney = from x in lstJourney where x.Id == jnd.JourneyId select x;
         if (null != vJourney && vJourney.Count() > 0)
                {
                    j = vJourney.FirstOrDefault();
                    crr.OptTopic = j.TopicId;
                }
         var vCampaignElement = from x in lstCampaignElement where x.LinkedJourney == j.Name select x;
         if (null != vCampaignElement && vCampaignElement.Count() > 0)
                {
                    ce = vCampaignElement.FirstOrDefault();
                    crr.Ccg_Id = ce.CCGId;
                    crr.ElementDescription = ce.Description.ToString();
                    crr.CampaignElementId = ce.Id;
          var vCampaign = from x in lstCampaign where x.Id == ce.CampaignId select x;
          if (null != vCampaign && vCampaign.Count() > 0)
                    {
                        c = vCampaign.FirstOrDefault();
                        crr.ActivityDate = c.AtTaskId;
                        crr.BrandName = c.Brand;
                        crr.CampaignId = c.Id;
                        crr.CampaignName = c.Name;
                        crr.CompanyName = c.Company;
                    }
                }
