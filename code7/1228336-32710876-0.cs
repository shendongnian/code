    public class Location
    {
        public String City { get; set; }
        public String Province { get; set; }
    }
    var t = "[{'City':'Alaminos','Province':'Pangasinan'},{'City':'Angeles','Province':'Pampanga'},{'City':'Antipolo','Province':'Rizal'}]";
    var type = JsonConvert.DeserializeObject<List<Location>>(t);
