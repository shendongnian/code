    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EmployeeLogic MLEdit = new EmployeeLogic();
    
            DepartmentLogic DL = new DepartmentLogic();
            DepartmentDropDownList.DataSource = DL.SelectAll();//This is the data source for DepartmentDropDownList
            DepartmentDropDownList.DataTextField = "DepartmentName";//This will appear at user side
            DepartmentDropDownList.DataValueField = "DepartmentID";//this the id of selected item 
            DepartmentDropDownList.DataBind();//Finally this will bind the dropdown with source. 
     DepartmentDropDownList.Items.Insert(0, new ListItem("0", "Select Item")); 
            Employee empp = MLEdit.SelectByID(Convert.ToInt32(Request.QueryString["EID"]));
            MName.Text = empp.EmployeeName;
            DepartmentDropDownList.SelectedValue =empp.DepartmentID.ToString();
        }
    }
    
    protected void submit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["EID"] != null)
        {
            EmployeeLogic MLUpdate = new EmployeeLogic();
            Employee emp = MLUpdate.SelectByID(Convert.ToInt32(Request.QueryString["EID"]));
            emp.EmployeeName = MName.Text;
            emp.DepartmentID = Convert.ToInt32(DepartmentDropDownList.SelectedItem.Value);
            emp.EmployeeID = Convert.ToInt32(Request.QueryString["EID"]);
            MLUpdate.Update(emp);
        }
    }
    <div class="form-group">
        <label for="exampleInputEmail1">Department</label>
        <asp:DropDownList ID="DepartmentDropDownList" runat="server"  OnSelectedIndexChanged="DepartmentDropDownList_SelectedIndexChanged1"> 
        </asp:DropDownList>
    </div>
