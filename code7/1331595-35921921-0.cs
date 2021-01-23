    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.SqlClient;
    using System.IO;
    public partial class Assignments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["ID"].ToString();
            DBL.AddAssignment obj12 = new DBL.AddAssignment();
            SqlDataReader sqlDR12 = null;
            sqlDR12 = obj12.Getbatchofstudent(Session["ID"].ToString().Trim());
            while(sqlDR12.Read())
            {
                Label1.Text=sqlDR12[9].ToString().Trim();
            }
            String BID = Label1.Text;
            DBL.AddAssignment obj = new DBL.AddAssignment();
            SqlDataReader sqlDR = null;
            sqlDR = obj.Viewassignmentingrid(BID);
            if (!IsPostBack)
            {
                grid1.DataSource = sqlDR;
                grid1.DataBind();
            }
            
        }
        protected void grid1_Disposed(object sender, EventArgs e)
        {
        }
        protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Button bts = e.CommandSource as Button;
            Response.Write(bts.Parent.Parent.GetType().ToString());
            if (e.CommandName.ToLower() != "upload")
            {
                return;
            }
            FileUpload fu = bts.FindControl("FileUpload4") as FileUpload;//here
            if (fu.HasFile)
            {
                bool upload = true;
                string fleUpload = Path.GetExtension(fu.FileName.ToString());
                if (fleUpload.Trim().ToLower() == ".xls" | fleUpload.Trim().ToLower() == ".xlsx")
                {
                    //Someting to do?...
                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    GridViewRow row = (GridViewRow)grid1.Rows[rowIndex];
                    Label AssignmentID = (Label)row.FindControl("LblASGNID");
                    Label AssignmentName = (Label)row.FindControl("LblCASGNName");
                    Label Coursename = (Label)row.FindControl("LblCourseName");
                    Label BatchID = (Label)row.FindControl("LabelBatch");
                    Label SubjectID = (Label)row.FindControl("LblSubID");
                    Label Subjectname = (Label)row.FindControl("LblSubname");
                    Label Submissiondate = (Label)row.FindControl("LblSubdate");
                    DateTime Submiteddate = DateTime.Now;
                    FileUpload fu1 = (FileUpload)row.FindControl("FileUpload4");
                    if (fu1.HasFile)
                    {
                        DBL.Assignmentuploadeddetails objf = new DBL.Assignmentuploadeddetails();
                        SqlDataReader sqlDRf = null;
                        sqlDRf = objf.GetcourseID(Session["ID"].ToString().Trim(), AssignmentID.Text.ToString());
                        if (sqlDRf.Read())
                        {
                            Response.Write("<script type=\"text/javascript\">alert('Your assignment For this subject has been already submited');</script>");
                            upload = false;
                        }
                        else if (Convert.ToDateTime(Submissiondate.Text.ToString()) < DateTime.Now)
                        {
                            Response.Write("<script type=\"text/javascript\">alert('Sorry Your Submission Date is Over');</script>");
                            upload = false;
                        }
                        else
                        {
                            DBL.AddAssignment obj12 = new DBL.AddAssignment();
                            SqlDataReader sqlDR12 = null;
                            sqlDR12 = obj12.Getbatchofstudent(Session["ID"].ToString().Trim());
                            while (sqlDR12.Read())
                            {
                                Session["ID2"] = sqlDR12[0].ToString().Trim();
                            }
                            DBL.Assignmentuploadeddetails obj = new DBL.Assignmentuploadeddetails();
                            obj.SID1 = Session["ID2"].ToString().Trim();
                            obj.AssignmentID1 = AssignmentID.Text;
                            obj.Assignmentname1 = AssignmentName.Text;
                            obj.Coursename1 = Coursename.Text;
                            obj.BatchID = BatchID.Text;
                            obj.SubjectID1 = SubjectID.Text;
                            obj.SubjectName1 = Subjectname.Text;
                            obj.SubmissionDate1 = Convert.ToDateTime(Submissiondate.Text.ToString());
                            obj.SubmitedDate1 = Submiteddate;
                            obj.UploadAssignment(obj);
                            fu.SaveAs(Server.MapPath("~/UpLoadPath/" + fu.FileName.ToString()));
                            string uploadedFile = (Server.MapPath("~/UpLoadPath/" + fu.FileName.ToString()));
                        }
                    }
                }
                else
                {
                    upload = false;
                    Response.Write("<script type=\"text/javascript\">alert('Sorry, Your file didn't uploaded to the server. Try again. Make sure that your are uploading .Docx or .Doc files');</script>");
                    // Something to do?...
                }
                if (upload)
                {
                    Response.Write("<script type=\"text/javascript\">alert('Your file has been successfully uploaded to the server. Thank you');</script>");
                }
            }
        }
        protected void bt_upload_Click(object sender, EventArgs e)
        {
        }
        protected void grid1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
        }
    }
