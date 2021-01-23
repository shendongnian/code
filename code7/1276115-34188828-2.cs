    [DataContract]
    public class AutoIDCardParameter
    {
        [DataMember(Name = "PolicyNumber")]
        public string PolicyNumber;
        [DataMember(Name = "EffectiveDate")]
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
