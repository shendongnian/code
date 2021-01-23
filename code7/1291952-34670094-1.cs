    public class Model
    {
        private bJCCI _jcci;
        public Double PerComplete
        {
            get { return _jcci.PercentageComplete ; }
            set
            {
                _jcci.PercentageComplete  = value;
                RaisePropertyChanged(nameof(PerComplete));
                RaisePropertyChanged(nameof(ClaimValue )); //Model property of ThisThisClaimValue field
            }
        }
    }
