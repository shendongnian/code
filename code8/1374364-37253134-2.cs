    namespace LightSwitchApplication
    {
        public partial class User
        {
            partial void Password_Validate(EntityValidationResultsBuilder results)
            {
    #if !SILVERLIGHT
                this.Password = YourEncryptFunction(this.Password);
    #endif
            }
        }
    }
