    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    
    public partial class Question : System.Web.UI.Page
    {
        ConnectionClass cl;
        DataTable dt,dt1;
        string QuestonId;
        protected void Page_Load(object sender, EventArgs e)
        {cl = new ConnectionClass();
                QuestonId = Request.QueryString["Id"];
                QuestonId = "1";
                string[] var = { "@id" };
                SqlDbType[] type = { SqlDbType.Int };
                string[] value = { QuestonId };
            if (!IsPostBack)
            {
                dt = cl.DatatableProcedure("GetQuestionDetail", var, type, value);
                StatementLabel.Text = dt.Rows[0].ItemArray[0].ToString();
                MemberNameLabel.Text = cl.ReturnNameFromId(dt.Rows[0].ItemArray[4].ToString()).ToString();
                DateLabel.Text = dt.Rows[0].ItemArray[5].ToString();
                TagsLabel.Text = dt.Rows[0].ItemArray[3].ToString();
                ProblemLabel.Text = dt.Rows[0].ItemArray[1].ToString();
                LikeDislike();
                TriedLabel.Text = dt.Rows[0].ItemArray[2].ToString();
                dt = cl.DatatableProcedure("GetAnswers", var, type, value);
                drawAnswers();
            }
        }
        public void LikeDislike()
        {
            string[] var = { "@id" };
            SqlDbType[] type = { SqlDbType.Int };
            string[] value = { QuestonId };
            dt1 = cl.DatatableProcedure("GetQuestionLikeDislike", var, type, value);
            LikeLabel.Text = dt1.Rows[0].ItemArray[0].ToString();
            DislikeLabel.Text = dt1.Rows[0].ItemArray[1].ToString();
        }
        public void drawAnswers()
        {
            Label lb = new Label();
            if(dt.Rows.Count==1)
            lb.Text = dt.Rows.Count.ToString() +" Answer";
            else
                lb.Text = dt.Rows.Count.ToString() + " Answer";
            AnswerPlaceHolder.Controls.Add(lb);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
                        new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                createDiv.ID = "createDiv" + i.ToString();
                Label[] l = new Label[5];
                for (int j = 0; j < 5; j++)
                {
                    l[j] = new Label();
                    l[j].Text = dt.Rows[i].ItemArray[j].ToString();
                    createDiv.Controls.Add(l[j]);
                }
                AnswerPlaceHolder.Controls.Add(createDiv);
            }
        }
        protected void LikeButton_Click(object sender, EventArgs e)
        {
            string[] var = { "@id" };
            SqlDbType[] type = { SqlDbType.Int };
            string[] value = { QuestonId };
            cl.executeProcedure("InsertLike", var, type, value);
            LikeDislike();
        }
        protected void UnlikeButton_Click(object sender, EventArgs e)
        {
            string[] var = { "@id" };
            SqlDbType[] type = { SqlDbType.Int };
            string[] value = { QuestonId };
            cl.executeProcedure("InsertUnlike", var, type, value);
            LikeDislike();
        }
    }
