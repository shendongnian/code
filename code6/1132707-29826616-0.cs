    public class mainitem() {
        public int id { get; set; }
        public int type { get; set; }
    }
    public class type() {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class myviewmodel() {
        public mainitem item { get; set; }
        public List<type> types { get; set; }
    }
    @Html.DropDownListFor(x => x.item.type, 
               new SelectList(Model.types, "id", "name"), "-Select-", 
               new { @class = "form-control" })
    
