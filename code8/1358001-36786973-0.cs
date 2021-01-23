    This classes/ structs need to be in /Models folder.
    Use struct opposed to class as it is lightweight and suitable in your case. Also except we have MVVM situation of two way data binding, we might just want to read so public {set; } is unnecessary.
    
    public struct CheckBoxViewModel
    {
        public CheckBoxViewModel(string name)
        {
            this.Name = name;
        }
        internal CheckBoxViewModel(DataRow row)// because I assume you know and will pass the correct Data from DataTable, this constructor might reduce some extra code.
        {
            this.Name = row["Name"] + "";
        }
        public string Name { get; private set; }
    }
    public static class common
    {
        public static IEnumerable<CheckBoxViewModel> GetList()
        {
            var list = new List<CheckBoxViewModel>();
            IDbCommand dbc = db.CreateCommand(); //db is your connection a static one.
            using (var r = dbc.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                while (reader.Read())
                {
                    var cbvm = new CheckBoxViewModel(reader.GetString(0));// assuming 0 is the index of your column
                    list.Add(cbvm);
                }
    
            }
            return list;
        }
    }
    
    public ActionResult Index()
    {
        return View(common.GetList());
    }
    
    Now in your view,
    @model IEnumerable<CheckBoxViewModel>
    <div class="container" name="checkboxList">
         @foreach (var item in Model)
         {
             <input type="checkbox" />@item.Name<br />
         }
    </div>
