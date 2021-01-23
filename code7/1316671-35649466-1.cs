    public partial class Default2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<ParentClass> pList = new List<ParentClass>()
                {
                    new ParentClass{Id=5, Name="V"},
                    new ParentClass{Id=6,Name="VI"},
                    new ParentClass{Id=7,Name="VII"},
                    new ParentClass{Id=8,Name="VIII"},
                    new ParentClass{Id=9,Name="IX"},
                    new ParentClass{Id=10,Name="X"},
                };
    
                grdParent.DataSource = pList;
                grdParent.DataBind();
            }
        }
    
        protected void grdParent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem == null || e.Row.RowType != DataControlRowType.DataRow)
            {
                return;
            }
    
            ParentClass p = e.Row.DataItem as ParentClass;
    
            var btn = e.Row.Cells[1].Controls[0] as LinkButton;
            btn.CommandArgument = p.Id.ToString();
        }
    
        protected void grdParent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int parentId = Convert.ToInt32(e.CommandArgument);
    
            var releventStudents = GetRepositary().FindAll(i => i.ParentId == parentId);
    
            grdChild.DataSource = releventStudents;
            grdChild.DataBind();
    
        }
    
        protected void grdChild_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem == null || e.Row.RowType != DataControlRowType.DataRow)
            {
                return;
            }
    
            //lookupCVRT work = (lookupCVRT)e.Row.DataItem;
            //GridView gv = sender as GridView;
    
            //if (work.ID != null)
            //{
            //    int index = gv.Columns.HeaderIndex("Select");
            //    if (index > -1)
            //    {
            //        e.Row.Cells[index].Attributes.Add("class", "gvCVRTRow");
            //        e.Row.Cells[index].ToolTip = "Click here to Edit Checklist";
            //    }
            //}         
        }
    
        private List<ChildClass> GetRepositary()
        {
            List<ChildClass> allChild = new List<ChildClass>();
            Random r = new Random();
    
            for (int i = 0; i < 50; i++)
            {
                ChildClass c = new ChildClass
                {
                    ChildId = i,
                    ParentId = r.Next(5, 10),
                    Name = "Child Name " + i,
                    Roll = i
                };
    
                allChild.Add(c);
            }
    
            return allChild;
        }
    }
    
    public class ParentClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class ChildClass
    {
        public int ParentId { get; set; }
        public int ChildId { get; set; }
        public int Roll { get; set; }
        public string Name { get; set; }
    }
