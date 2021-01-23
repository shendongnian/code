      public static List<string> SortElements(string TemplatePath)
      {
         List<string> ElementsList = new List<string>();
         ElementsList.Add(XMLName);
         ElementsList.Add(XMLAddress);
         ElementsList.Add(XMLHomeNumber);
         ElementsList.Add(XMLMobileNumber);
         ElementsList.Add(XMLEmail);
         ElementsList.Add(XMLDriversLicence);
         ElementsList.Add(XMLCarOwner);
         ElementsList.Add(XMLPStatement);
         string SkillsAndQuantitiesElement = "<SkillsAndQualities>";
         for (int i = 0; i < ArrSkills.GetLength(0); i++)
         {
            for (int j = 0; j < ArrSkills.GetLength(1); j++)
            {
               if (i == 0)
               {
                  SkillsAndQuantitiesElement += "<Skill>" + ArrSkills[i, j] + "</Skill>";
               }
               else
               {
                  SkillsAndQuantitiesElement += "<Quality>" + ArrSkills[i, j] + "</Quality>";
               }
            }
         }
         SkillsAndQuantitiesElement += "</SkillsAndQualities>";
         ElementsList.Add(SkillsAndQuantitiesElement);
         ElementsList.Add(XMLEd);
         ElementsList.Add(XMLWork);
         ElementsList.Add(XMLInterest);
         ElementsList.Add(XMLRef);
         return ElementsList;
      }
