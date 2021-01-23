        public class InspectionReport
        {
            //there are other unrelated members as well
            private string complexID;
            //constructor would be here
            //getters and setters
            public void setComplexID(string inputCustomerName, DateTime inputInspectionDate)
            {
                complexID = Convert.ToString(inputCustomerName + inputInspectionDate);
            }
            public string getComplexID()
            {
                return complexID;
            }
        }
