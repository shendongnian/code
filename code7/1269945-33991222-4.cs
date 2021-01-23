    public partial class Results : Form 
    {
        ...
        FormLevel1 rez1 = new FormLevel1(this); //pass this instance of Results into FormLevel1
        ...
        public void Calculations() //Add public keyword so that it is accessible from FormLevel1
        {
            ...
        }
    }
    public partial class FormLevel1: Form 
    {
        Results resultForm;
        
        public FormLevel1(Results callingForm) //modify constructor to accept Results
        {
            resultForm = callingForm;  
        }
        void TimerCompleted() //Call this when Timer finish its stuff
        {
            resultForm.Calculations();
        }
        ...
    }
