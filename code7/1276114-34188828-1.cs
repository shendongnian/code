    public class AutoIDCardParameter
    {
        [DataMember]
        public string PolicyNumber;
        [DataMember]
        private string _EffectiveDate {
            get {
                return EffectiveDate.ToString("yyyy-MM-DDTHH:mm:ss");
            }
            set {
                DateTime.TryParse(value, out EffectiveDate);
            }
        }
        public DateTime EffectiveDate;
        // ....
    }
