    public class SomeConsumerClass
    {
        public void SomeMethod()
        {
            SomeLocalizableClass c = new SomeLocalizableClass();
            c.IntSetting["fr-FR"] = 4;      //Sets the french setting
            c.IntSetting = 10;              //Sets the current culture setting
            int multipleSetting = c.IntSetting * c.IntSetting;
        }
    }
