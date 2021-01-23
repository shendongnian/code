    namespace LightSwitchApplication
    {
        public partial class User
        {
            partial void Password_Validate(EntityValidationResultsBuilder results)
            {
                this.Password = YourEncryptFunction(this.Password);
            }
        }
    }
