    // you will have a history of Records
    // a Record contains the Patient + obesity result
    public class Record 
    {
       public Patient Patient {get; private set;} 
       public bool ObesityResult {get; private set; }
       public Record(Patient patient, bool obesityResult) 
       {
           this.Patient = patient; 
           this.ObesityResult = obesityResult; // save the obese result
       }
    }
    // now this class will handle the history.
    public class RecordHistory 
    {
        private ArrayList history; 
        public void Add(Patient patient) 
        { 
            var record = new Record(patient, patient.obese());  // pass the obesity result
            history.Add(patient);  // DO some magic here to keep only 5
        }
       public ArrayList GetHistory() 
       {
          return history;
       }
    }
