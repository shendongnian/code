    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.SqlClient;
    using System.Data;
    using System.Configuration;
    public partial class Student_Examdemo : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView1.DataSource = GetData("SELECT top 2 Question, Option1, Option2, Option3, Option4, CorrectAns, Explanation FROM Questions");
            GridView1.DataBind();
          
            GridView2.DataSource = GetData("SELECT top 2 Question, Option1, Option2, Option3, Option4, CorrectAns, Explanation FROM Questions WHERE SectionId=2");
            GridView2.DataBind();
          
        }
    }
    private DataSet GetData(string query)
    {
        string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlCommand cmd = new SqlCommand(query);
        using (SqlConnection con = new SqlConnection(conString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds);
                    return ds;
                }
            }
        }
    }
   
            protected void btn_Click(object sender, EventArgs e)
          {
                RadioButton r1, r2, r3, r4;
                HiddenField hdn;
                int count1 = 0;
                int count2 = 0;
                int neg1 = 0;
                int neg2 = 0;
                int total=0;
                int totalgrid1=0;
                int totalgrid2=0;
               
                int attempt1 = 0;
                int attempt2 = 0;
                int Tattempt = 0;
                int correct = 0;
                int correct1 = 0;
                int correct2 = 0;
                
                string selans = "-1";
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    r1 = (RadioButton)GridView1.Rows[i].Cells[0].FindControl("rad1");
                    r2 = (RadioButton)GridView1.Rows[i].Cells[0].FindControl("rad2");
                    r3 = (RadioButton)GridView1.Rows[i].Cells[0].FindControl("rad3");
                    r4 = (RadioButton)GridView1.Rows[i].Cells[0].FindControl("rad4");
                    hdn = (HiddenField)GridView1.Rows[i].Cells[0].FindControl("hf");
                    if (r1.Checked)
                    {
                        selans = r1.Text;
                
                    }
                    else if (r2.Checked)
                    {
                        selans = r2.Text;
                
                    }
                    else if (r3.Checked)
                    {
                        selans = r3.Text;
                
                    }
                    else if (r4.Checked)
                    {
                        selans = r4.Text;
                
                    }
                    
                    if(r1.Checked || r2.Checked || r3.Checked || r4.Checked)
                    {
                       attempt1++;
                       if (hdn.Value == selans)
                       {
                          count1++;
                           correct1++;
                       }
                        else
                        {
                          neg1--;
                        }
                    }
                    totalgrid1 = count1 + neg1;
            
                    
                }
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            r1 = (RadioButton)GridView2.Rows[i].Cells[0].FindControl("rad1");
            r2 = (RadioButton)GridView2.Rows[i].Cells[0].FindControl("rad2");
            r3 = (RadioButton)GridView2.Rows[i].Cells[0].FindControl("rad3");
            r4 = (RadioButton)GridView2.Rows[i].Cells[0].FindControl("rad4");
            hdn = (HiddenField)GridView2.Rows[i].Cells[0].FindControl("hf");
            if (r1.Checked)
            {
                selans = r1.Text;
                
            }
            else if (r2.Checked)
            {
                selans = r2.Text;
                
            }
            else if (r3.Checked)
            {
                selans = r3.Text;
                
            }
            else if (r4.Checked)
            {
                selans = r4.Text;
                
            }
            
            if (r1.Checked || r2.Checked || r3.Checked || r4.Checked)
            {
                attempt2++;
                if (hdn.Value == selans)
                {
                    count2++;
                    correct2++;
                }
                else
                {
                    neg2--;
                }
            }
            totalgrid2 = count2 + neg2;
            
        }
        total = totalgrid1 + totalgrid2;
        Tattempt = attempt1 + attempt2;
        correct = correct1 + correct2;
        Label2.Text = total.ToString();
        Label3.Text = Tattempt.ToString();
        Label4.Text = correct.ToString();
        Response.Redirect("/Student/Result.aspx?Score=" + Label2.Text +"&AttemptedQues=" +Label3.Text+ "&CorrectAns=" +Label4.Text);
    }
    }
