    var service = new EligibilityTransformationService();
    EligibilityBenefitDocument eligibilityBenefitDocument = service.Transform271ToBenefitResponse(response271Stream);
    eligibilityBenefitDocument.EligibilityBenefitResponses = eligibilityBenefitDocument.EligibilityBenefitResponses;
    foreach (EligibilityBenefitInformation benefitInfo in eligibilityBenefitDocument.EligibilityBenefitResponses[0].BenefitInfos)
           {               
               if (benefitInfo.InfoType.Code == "V")
                   return Tuple.Create(false, "Medicare cannot process");
               if (benefitInfo.InfoType.Code == "6")
                   return Tuple.Create(false, "Inactive Policy");
               if (benefitInfo.InsuranceType.Code == "HN" || benefitInfo.InsuranceType.Code == "12")
               {
                   try
                   {
                       return Tuple.Create(false, "MADV " + benefitInfo.Identifications[0].Id + " " + benefitInfo.RelatedEntities[0].Name.LastName);
                   }
                   catch
                   {
                       return Tuple.Create(false, "MADV");
                   }
               }
           }
