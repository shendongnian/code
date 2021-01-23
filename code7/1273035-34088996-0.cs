     public partial class Member
    {
        partial void OnGenderChanging(string value)
        {
            if (((value.ToLower() != "male") || (value.ToLower() != "female")))
            {
                throw new ValidationException("Must be Male or Female.");
            }
        }
