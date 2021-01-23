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
            if (Session["phoneCheckboxList"] != null)
            {
                List<CheckBox> phoneCheckboxList = Session["phoneCheckboxList"] as List<CheckBox>;
                BuildTable(phoneCheckboxList);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            List<CheckBox> phoneCheckboxList = new List<CheckBox>();
            BuildTable(phoneCheckboxList);
        }
        private void BuildTable(List<CheckBox> phoneCheckboxList)
        {
            foreach (Phone p in building.Phones)
            {
                TableCell cell_switch = new TableCell();
                cell_switch.Controls.Add(p.chkBox);
                row.Cells.Add(cell_switch);
                phoneCheckboxList.Add(p.chkBox);
            }
            if (Session["phoneCheckboxList"] == null)
                Session["phoneCheckboxList"] = phoneCheckboxList;
        }
    }   
