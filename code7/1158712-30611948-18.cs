    namespace CarNameSpace
    {
       public class Car()
       {
          public void Drive(IDriver driver)
          {
             if(driver.Age > 18)
             {
                driver.Drive();
             }
          }
       }
    }
