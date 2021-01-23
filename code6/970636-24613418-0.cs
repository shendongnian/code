    public class BookInfo
    {
    	public string EAN {get;set;}
    	public string Title {get;set;}
    	public int Quantity {get;set;}
    }
    
    public IEnumerable<BookInfo> stockEtatQty()
    {   
        ...
    	
        var q = from x in afList
                select new BookInfo { EAN=x.EAN, Title=x.title, Quantity=x.qty };
    
        return q;
    }
    
    private void QuantityToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ServiceStock sstock = new ServiceStock();
        var q = sstock.stockEtatQty();
    	
    	var message = string.Join(Environment.NewLine, 
    							  q.Select(item => String.Format("{0} {1} {2}", item.EAN, item.Title, item.Quantity)));
        MessageBox.Show(message);
    }
