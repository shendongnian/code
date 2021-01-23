    abstract class Servicer
    {
        ...
        public abstract IEnumerable<string> ServiceReq(char request);
    }
    class Servicer1 : Servicer
    {
        public override IEnumerable<string> ServiceReq(char request)
        {
            string s1 = "Sam ate nuts";
            yield return "Checked Servicer1";
            if (s1.Contains(request))
            {
                yield return "Request found in Servicer 1";
            }
            else if (successor != null)
            {
                yield return successor.ServiceReq(request);
            }
        }
    }
    // Similar changes for Servicer2
