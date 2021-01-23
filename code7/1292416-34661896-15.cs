    public class PatientViewModel: INotifyPropertyChanged
        {
           public int ID {get; set;}
           public string FirstName {get; set;}
           public string LastName {get; set;}
           //Each patient has a set of test results, so we create a list.
           public  List<TestResult> PatientTestResults {get; set;}
        }
