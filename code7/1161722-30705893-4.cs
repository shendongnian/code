    public class DeserializedAndNormilizedObject
    {
        public IEnumerable<Division> Divisions { get; set; }
        public IEnumerable<Division> WalletDivisions { get; set; }
    }
    var obj = new DeserializedAndNormilizedObject();
    var devisionsSet = result.DivisionSets.FirstOrDefault(x => x.Name == "divisions");
    if (devisionsSet != null)
    {
        obj.Divisions = devisionsSet.Divisions;
    }
    // Same for walletDivisions
