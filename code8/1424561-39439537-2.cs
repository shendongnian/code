    public class Person : RealmObject
    {
        public bool? IsAmbivalent { get; set; }
    ...
    _realm.All<Person>().Where(p => p.IsAmbivalent == null);
