    public class PayslipMain
    {
        // your properties...
        public int cumulatives_ID;
        public List<Details> PayslipMainDetails { get; private set; }
    }
    public PayslipMain(/* your params...*/)
    {
        // your assignings...
        pension_message = pensionmessage;
        PayslipMainDetails = new List<Details>();
    }
    // wherever you create your list of details, do this
    payslipMainInstance.PayslipMainDetails.AddRange(BuildList());
