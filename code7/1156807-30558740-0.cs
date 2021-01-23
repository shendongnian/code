    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            if (Session["showFiles"] != null)
            {
                bool flag = (bool)Session["showFiles"];
                if (flag == true)
                {
                    fileSaving fs = new fileSaving();
                    List<fileSaving> fileslist = fs.filesList(hiddenLBL.Text);
                    addTable(fileslist);
                }
            }
        }
        ExpScheduleClass ESCC = new ExpScheduleClass();
        List<string> labCourses = ESCC.getCourseList();
        // dynamically create a dropdown list (aka DDL)
        DDLCourses = new DropDownList();
        DDLCourses.DataSource = labCourses; // set the data source
        DDLCourses.DataBind(); // bind the data to the DDL control
        DDLCourses.AutoPostBack = true;
        DDLCourses.SelectedIndexChanged += DDLCourses_SelectedIndexChanged;
        coursePH.Controls.Add(DDLCourses);
       
    }
    private void DDLCourses_SelectedIndexChanged(object sender, EventArgs e)
    {
        string[] coursesIDArr = DDLCourses.SelectedValue.Split(' ');
        /* courseLBL.Text = coursesIDArr[0];
         string courseID = coursesIDArr[0];//take the id from the list*/
        courseLBL.Text = coursesIDArr[2];
        classLBL.Text = coursesIDArr[4];
        currnetYearLBL.Text = coursesIDArr[6];
        semesterLBL.Text = coursesIDArr[8];
        courseLBL.ForeColor = System.Drawing.Color.Black;
        currnetYearLBL.ForeColor = System.Drawing.Color.Black;
        semesterLBL.ForeColor = System.Drawing.Color.Black;
        classLBL.ForeColor = System.Drawing.Color.Black;
        ExpScheduleClass SIEGL = new ExpScheduleClass();
        List<String> lessonsList = SIEGL.getLessonList(coursesIDArr[2]);
        DDLLessons.DataSource = lessonsList; // set the data source
        DDLLessons.DataBind();
    }
    protected void DDLLessons_SelectedIndexChanged(object sender, EventArgs e)
    {
        string[] lessonsIdArr = DDLLessons.SelectedValue.Split(' ');
        string lessonID = lessonsIdArr[0];
        lessonLBL.Text = lessonID;
        dateLBL.Text = lessonsIdArr[1];
        lessonLBL.ForeColor = System.Drawing.Color.Black;
        hiddenLBL.Text = lessonID;
        fileSaving fs = new fileSaving();
        List<fileSaving> fileslist = fs.filesList(lessonID);
        addTable(fileslist);
        Session["showFiles"] = true;
        
    }
    private void addTable(List<fileSaving> fs)
    {
        foreach (fileSaving f in fs)
        {
            UpdatePanel up = new UpdatePanel();
            up.ID = "UpdatePanel-" + f.FileName;
            up.UpdateMode = UpdatePanelUpdateMode.Conditional;
            Table T = new Table();
            T.CssClass = "filesTBL";
            //------------Header Row------------------------------------------------
            TableRow hTR = new TableRow();
            TableCell td1 = new TableCell();
            Image fileImg = new Image();
            fileImg.ImageUrl = "images/" + f.FileExtension + ".png";
            td1.Controls.Add(fileImg);
            hTR.Cells.Add(td1);
            TableCell td2 = new TableCell();
            td2.Text = f.ExpName;
            hTR.Cells.Add(td2);
            TableCell td3 = new TableCell();
            Image expImg = new Image();
            expImg.ImageUrl = "images/magnet.png";
            td3.Controls.Add(expImg);
            hTR.Cells.Add(td3);
            T.Rows.Add(hTR);
            //------------Middle Row------------------------------------------------
            TableRow mTR = new TableRow();
            TableCell td4 = new TableCell();
            td4.Text = "";
            mTR.Cells.Add(td4);
            TableCell td5 = new TableCell();
            td5.Text = f.TeamID.ToString();
            mTR.Cells.Add(td5);
            TableCell td6 = new TableCell();
            Image teamImg = new Image();
            teamImg.ImageUrl = "images/team3.png";
            td6.Controls.Add(teamImg);
            mTR.Cells.Add(td6);
            T.Rows.Add(mTR);
            //------------Last Row------------------------------------------------
            TableRow lTR = new TableRow();
            TableCell td7 = new TableCell();
            HyperLink downloadLink = new HyperLink();
            //downloadLink.Attributes.Add("href", "/igroup39/test2/project/reportFiles/" + f.FileName);
            downloadLink.Attributes.Add("href", "http://proj.ruppin.ac.il/igroup39/test2/tar5/tar5.zip");
            downloadLink.ImageUrl = "images/download2.png";
            downloadLink.ToolTip = "לחץ להורדה";
            td7.Controls.Add(downloadLink);
            lTR.Cells.Add(td7);
            TableCell td8 = new TableCell();
            if (f.ReportGrade != -1)
            {
                td8.Text = f.ReportGrade.ToString();
            }
            else
            {
                TextBox tb = new TextBox();
                tb.ID = f.FileName + "-tb";
                gFN = tb.ID;
                tb.Width = 40;
                td8.Controls.Add(tb);
                Button btn = new Button();
                btn.ID = f.FileName + "-btn";
                btn.Text = "הזן ציון";
                btn.Click += new EventHandler(btn_Click);
                td8.Controls.Add(btn);
            }
            lTR.Cells.Add(td8);
            TableCell td9 = new TableCell();
            Image gradeImg = new Image();
            gradeImg.ImageUrl = "images/grade.png";
            td9.Controls.Add(gradeImg);
            lTR.Cells.Add(td9);
            T.Rows.Add(lTR);
            up.ContentTemplateContainer.Controls.Add(T);
            Page.Form.Controls.Add(up);
            //filesTablesPH.Controls.Add(up);
        }
    }
    protected void btn_Click(object sender, EventArgs e)
    {
       
        Button mybtn = (Button)sender;
        string btnID = mybtn.ID;
        string[] file_Name = btnID.Split('-');
        string tbID = file_Name[0] + "-tb";
        string grade = ((TextBox)filesTablesPH.FindControl(tbID)).Text;
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert("+grade+")", true);
    }
