    protected void Page_Load(object sender, EventArgs e)
    {
    
        hfm mymaster = (hfm)Page.Master;
        lcont lc = mymaster.getlcont();
        lc.myevent += delegate(string st)
         {
             //slbl.Text = st;
    
             string str =st;
             myfunc(str); // pass as param
          }
     }
    
     protectd void myfun(string str)  // see signature
     {
         //i want to access the string value "st" here.
     }
