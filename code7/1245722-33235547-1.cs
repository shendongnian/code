    public class MembersCollection: IList<CompanyMemberViewModel>
    ...
        public override string ToString()
        {
            return string.Join(", ", this);
        }
    }
