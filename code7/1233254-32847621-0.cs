    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                counter1++;
                txtCounter.Text = counter1.ToString();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("\nException raised!");
            Debug.WriteLine("Source :{0} ", ex.Source);
            Debug.WriteLine("Message :{0} ", ex.Message);
           // Raise the exception
           // throw;   
           // or assign the correct status and status code
     
           Response.ClearHeaders();
           Response.ClearContent(); 
           Response.Status = ex.Message;
           Response.StatusCode = 500;
        }
    } 
