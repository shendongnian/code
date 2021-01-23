    static string mainpath = "http://triad102:1001";
    
    public static  void  getSubWebs(string path)
    {          
        try
        {
            ...
            foreach (Web orWebsite in oWebsite.Webs)
            {
                string newpath = path + orWebsite.ServerRelativeUrl; 
                getSubWebs(newpath);
            }
        }
        catch (Exception ex)
        {          
        }           
    }
