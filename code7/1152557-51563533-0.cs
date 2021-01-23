    public class ViewSubjectGradeViewModel
    {
       public ViewSubjectGradeViewModel()
       {
           //default ctor
       }
       [PreferredConstructor()] //add this attribute
       public ViewSubjectGradeViewModel(IEnumerable<ScoreModel> addedSubjectGradePairs)
       {
           //dependency injected ctor
       }
    }
