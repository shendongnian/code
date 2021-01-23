    protected void Pagination_Click(object sender, EventArgs e)
    {
        int Count = Convert.ToInt32(DRCount.Text);
        LinkButton LinkButton = (LinkButton)sender;
        int Select = Convert.ToInt32(LinkButton.Text);
        int Num2 = Count * Select;
        int Num1 = Num2 - Count;
        var otherClass = new OtherClass();
        otherClass.GetData(Num1,Num2);
    }
    
    
    01.aspx.cs page:
    
    public void GetData(int Num1, int Num2)
    {
        int Count = Convert.ToInt32(this.Master.Count);
        int PriceSort = Convert.ToInt32(this.Master.Price);
        string NameSort = this.Master.Name.ToString();...
    }
