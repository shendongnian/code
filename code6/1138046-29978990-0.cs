    //this class allows to separate the winform (equivalent to a view) from 
    //the data layer, you can see it as a ViewModel
    public class FormNamePatient {
        public Int32 Id { get; set;}
        public String FirstName { get; set;}
        public String LastName { get; set;}
    }
    private BindingList<FormNamePatient> _patients;
    try {
       //the using guarantees the disposing of the resources 
       //(avoiding memory link and so on)
       using ( hospitaldbEntities context = new hospitaldbEntities() ) {
           _patients = new BindindList<FormNamePatient>(
               context.patients.Select(
                  x => new FormNamePatient {
                      Id = x.Id,
                      FirstName = x.FirstName,
                      LastName = x.LastName,
                  }).ToList() // this materialize the list
                              // in other (bad ?) words, this allows the list
                              //to live out of the context (<=> using)
           );       
       }
       PatientlistBoxId.DataSource ) = _patients;
       //now if you alter (not erase, but edit, change...) _patients you 
       //update the control
       PatientlistBoxId.DisplayMember = "FirstName";
    } catch (Exception ex) {
      Console.WriteLine(ex);
    }
