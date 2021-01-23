        public interface IHasDefaultMemberValues
        {
            bool MembersAreDefault();
        }
    Next, implement that interface for `Address`:
        public class Address : IHasDefaultMemberValues
        {
            // Properties as above.
            #region IHasDefaultMemberValues Members
            public bool MembersAreDefault()
            {
                return Street1 == null && Street2 == null && City == null && State == null && Zip == null && Country == null;
            }
            #endregion
        }
    Finally, modify `Customer` identically to solution #1.
    This solution is performant, but depends upon `MembersAreDefault()` being correctly maintained when new properties are added to `Customer`.
