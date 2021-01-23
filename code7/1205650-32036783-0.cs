    public class Building
    {
        public List<Phone> Phones { get; set; }
        public Building()
        {
            Phones = new List<Phone>()
            { 
                new Phone(),
                new Phone()
            };
        }
    }
    public class Phone
    {
       public CheckBox chkBox { get; set; }
       public Phone()
       {
           chkBox = new CheckBox();
           chkBox.CheckedChanged += chkBox_CheckedChanged;
           chkBox.AutoPostBack = true;
       }
    
       void chkBox_CheckedChanged(object sender, EventArgs e)
       {
           throw new NotImplementedException();
       }
    }
    public partial class Default : System.Web.UI.Page
    {
        Building building = new Building();
        protected void Page_Init(object sender, EventArgs e)
        {
            foreach (Phone p in building.Phones)
            {
                TableCell cell_switch = new TableCell();
                cell_switch.Controls.Add(p.chkBox);
                row.Cells.Add(cell_switch);
            }
        }
    }
