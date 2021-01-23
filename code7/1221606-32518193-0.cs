    GuideLineSectionsViewModel FindGuidelineType(GuideLineSectionsViewModel guidelineSectionModel)
                {
                    //GuideLineSectionsViewModel result = new GuideLineSectionsViewModel();
                    string title = guidelineSectionModel.Title;
                    int count = Regex.Matches(title, "Low Intensity").Count;
                    if (count > 0)
                    {
                       foreach(SectionViewModel svm in guidelineSectionModel.SectionsSet)
                       {
                          foreach(ProblemViewModel pvm in svm.ProblemsSet)
                          {
                             pvm.Identified = true;
                          }
                        }
                    }
                    return guidelineSectionModel; 
                }
