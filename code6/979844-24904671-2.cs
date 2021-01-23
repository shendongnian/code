    interface ISortable
    {
        int SordOrder { get; }
    }
    class AllergyComponentEntity : ISortable
    {
        public string AllergyName { get; set; }
        public int SortOrder { get; set; }
    }
    class VitalComponentEntity : ISortable
    {
        public bool VitalTemp { get; set; }
        public bool VitalResp { get; set; }
        public bool VitalPulse { get; set; }
        public int SortOrder { get; set; }
    }
    class AllComponentEntity : IEnumerable<ISortable>
    {
        public AllergyComponentEntity Allergy { get; set; }
        public List<VitalComponentEntity> VitalList { get; set; }
        public IEnumerable<ISortable> GetProperties()
        {
            yield return Allergy;
            foreach (var vce in VitalList)
                yield return vce;
        }
        private IEnumerable<ISortable> GetSorted()
        {
            return GetProperties().OrderBy(x => x.SordOrder);
        }
        public IEnumerator<ISortable> GetEnumerator()
        {
            return GetSorted().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetSorted().GetEnumerator();
        }
    }
