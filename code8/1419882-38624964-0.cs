    [Serializable]
    public class ProfileForm
    {
        // these are the fields that will hold the data
        // we will gather with the form
        [Prompt("What is your first name? {||}")]
        public string FirstName;
        [Prompt("What is your last name? {||}")]
        public string LastName;
        [Prompt("What is your gender? {||}")]
        public Gender Gender;
        // This method 'builds' the form 
        // This method will be called by code we will place
        // in the MakeRootDialog method of the MessagesControlller.cs file
        public static IForm<ProfileForm> BuildForm()
        {
            return new FormBuilder<ProfileForm>()
                    .Message("Welcome to the profile bot!")
                    .OnCompletion(async (context, profileForm) =>
                    {
                        // Tell the user that the form is complete
                        await context.PostAsync("Your profile is complete.");
                    })
                    .Build();
        }
    }
    // This enum provides the possible values for the 
    // Gender property in the ProfileForm class
    // Notice we start the options at 1 
    [Serializable]
    public enum Gender
    {
        Male = 1, Female = 2
    };
    
