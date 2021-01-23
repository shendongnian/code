    //Declare a global variable
    public Boolean IsHoliday = false;
    //Attribute 
    public class CheckHoliday : System.Attribute
    {
        //Here I want exit from consumer method if today is holiday ?
        //this ain't possible 
        public CheckHoliday()
        {
            //if  today is holiday  make IsHoliday= true
            IsHoliday= true;
            //Else keep it false
        }
    }
    public class TestClass
    {
        [CheckHoliday]
        public void TestMethod()
        {
           //Here you can exit  if today is holiday
            if (IsHoliday)
                return;
            //Else Method Logic here
        }
    }
