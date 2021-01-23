    [Serializable]
    public class CountryModel {
       public int ID { get; set; }
       public string Title { get; set; }
       public List<ValueModel> Values { get; set; }
    }
    [Serializable]
    public class ValueModel {
       public int ValueID { get; set; }
       public string Type { get; set; }
    }
