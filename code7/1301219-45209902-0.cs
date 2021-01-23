    public class ConditionsCollectionModel
    {
        [XmlElement("forbidden")]
        public List<ForbiddenModel> ForbiddenCollection { get; set; }
        [XmlElement("required")]
        public List<RequiredModel> RequiredCollection { get; set; }
        public bool ShouldSerializeForbiddenCollection(){
        return (ForbiddenCollection !=null && ForbiddenCollection.Count>0);
    }
