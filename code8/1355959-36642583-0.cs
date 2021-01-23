	protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
		{
			cl = new ConnectionClass();
			QuestonId = Request.QueryString["Id"];
			string[] var = { "@id" };
			SqlDbType[] type = { SqlDbType.Int };
			string[] value = { QuestonId };
			dt1 = cl.DatatableProcedure("GetQuestionLikeDislike", var, type, value);
			LikeLabel.Text = dt1.Rows[0].ItemArray[0].ToString();
			DislikeLabel.Text = dt1.Rows[0].ItemArray[1].ToString();
			dt = cl.DatatableProcedure("GetAnswers", var, type, value);			
		}		
    }
