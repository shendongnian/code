    public class DataExistanceAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var repo = new Repo(); 
                //Cast it to the data type, i am just casting it to int...
                var enteredValue = (int)value;
                // Code to check if the entered value exists in the database...
                if (reop.DataToCheck.Find(value) == null)
                {
                    return false;
                }
            }
    
            return true;
        }
    }
