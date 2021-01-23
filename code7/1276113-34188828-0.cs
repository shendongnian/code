    public class AutoIDCardParameter
    {
        [DataMember]
        public string PolicyNumber { get; set; }
        [DataMember]
        private string _EffectiveDate {
            get {
                return EffectiveDate.ToString();
            }
            set {
                DateTime.TryParse(value, out EffectiveDate);
            }
        }
        public DateTime EffectiveDate;
        // ....
    }
