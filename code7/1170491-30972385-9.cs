    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            multi();
        }
    }
    public void  multi()
    {
      if(ddlnumA.SelectedValue!="-1" && ddlNumB.SelectedValue!="-1")
      {
        Decimal NumA=Convert.ToDecimal(ddlNumA.SelectedValue);
        Decimal NumB=Convert.ToDecimal(ddlNumB.SelectedValue);
        Decimal disc = NumA*NumB;
        Decimal totalCost = (NumA- disc ); 
        txttotal.Text = "$" + totalCost.ToString();
        txtdiscount.Text = "$" + disc.ToString();
      } 
   
    }
    //here are the change events of dropdown
    protected void ddlnumA_SelectedIndexChanged(object sender, EventArgs e)
    {
       multi();    
    }
    protected void ddlNumB_SelectedIndexChanged(object sender, EventArgs e)
    {
       multi();    
    }
    
