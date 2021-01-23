    public class Members: IList<CompanyMemberViewModel>
    ...
        public override string ToString()
        {
            return string.Join(", ", this);
        }
    }
