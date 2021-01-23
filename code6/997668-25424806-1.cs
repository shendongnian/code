     public partial class Process : System.Web.UI.Page
     {
      protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder SB = new StringBuilder();
        // Padding to circumvent IE's buffer.
        Response.Write(new string('*', 256));
        Response.Flush();
        // Initialization
        UpdateProgress(0, "Initializing task.");
        try
        {
            foreach (yourloophere)
            {
                        UpdateProgress(increment, db.Name + " Backup Started....");
                //your process code
                        UpdateProgress(increment, db.Name + " Backup Completed!");
