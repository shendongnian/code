        public class MaxXXAgeMembers
            {
                public MaxXXAge MaxXXAge { get; private set; }
                public string Description { get; private set; }
    
                public static readonly IReadOnlyList<MaxXXAgeMembers> Options = new ReadOnlyCollection<MaxXXAgeMembers>(new[]
                {
                    new MaxXXAgeMembers { MaxXXAge =  MaxXXAge.OneDay, Description = Strings.SettingSync_OneDay},
    .......
                });
    
                public static MaxXXAgeMembers FromMaxXXAge(MaxXXAge maxXXAge)
                {
                    return Options.First(option => option.MaxXXAge == maxXXAge);
                }
            }
