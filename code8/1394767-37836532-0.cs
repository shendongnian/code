    public class MyMemberRepo : IGenericRepository<Member>
    {
        public IEnumerable<Member> GetAllMember()
        {
            // 1. Load the data from the data store into an IEnumerable<MemberDto>.
            // 2. Map the IEnumerable<MemberDto> to an IEnumerable<Member>, perhaps
            //   using something like the open source AutoMapper project.
            // 3. Return the IEnumerable<Member>.
        }
        // ... other interface implementations...
    }
