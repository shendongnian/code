    public class ExcpFlsV:ExcpM
    {
        bool Rtrn { get { return false; } }
        public ExcpFlsV(string bsMsg, int CallerLevel=2)
            : base(bsMsg, CallerLevel)
        {
    
        }
    }
    public bool SecondLevel(string caller, int callerLvl = 3)
    {
        return testStacktrace(" called by SecondLevel " + caller, callerLvl);
    }
    public bool testStacktraceFirstLvl(string caller, int callerLvl = 2)
    {
      return new ExcFlsBlV("testStacktrace " + caller, calLvl).Rtrn;
    }
