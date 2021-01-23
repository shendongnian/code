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
           Response.Clear();     
           Response.TrySkipIisCustomErrors = true
           Response.ContentType = "text/plain";
           Response.StatusCode = (int)HttpStatusCode.InternalServerError;
           Response.Write(ex.Message);
           // Send the output to the client.
           Response.Flush();
        }
    } 
