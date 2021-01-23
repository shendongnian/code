        public class GroupsSummaryComparer : IEqualityComparer<GroupsSummary>
        {
            public bool Equals(GroupsSummary x, GroupsSummary y)
            {
                if (object.ReferenceEquals(x, y))
                    return true;
                else if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
                    return false;
                return x.PayToStr1 == y.PayToStr1 && x.PayToStr2 == y.PayToStr2 && x.PayToCity == y.PayToCity && x.PayToState == y.PayToState;
            }
            public int GetHashCode(GroupsSummary obj)
            {
                if (obj == null)
                    return 0;
                int code;
                if (obj.PayToStr1 != null)
                    code ^= obj.PayToStr1.GetHashCode();
                if (obj.PayToStr2 != null)
                    code ^= obj.PayToStr2.GetHashCode();
                if (obj.PayToCity != null)
                    code ^= obj.PayToCity.GetHashCode();
                if (obj.PayToState != null)
                    code ^= obj.PayToState.GetHashCode();
                return code;
            }
        }
