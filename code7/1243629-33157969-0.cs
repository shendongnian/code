    // you will have a history of Records
    // a Record contains the Patient + obesity result
    public class Record 
    {
       public Patient Patient {get; private set;} 
       public bool ObesityResult {get; private set; }
       public Record(Patient patient) 
       {
           this.Patient = patient; 
           this.ObesityResult = patient.obese(); // save the obese result
       }
    }
    // now this class will handle the history.
    public class RecordHistory 
    {
        private ArrayList history; 
        public void Add(Patient patient) 
        { 
            var record = new Record(patient); 
            history.Add(patient);  // DO some magic here to keep only 5
        }
       public ArrayList GetHistory() 
       {
          return history;
       }
    }
