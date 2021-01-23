    private void Form1_Load(object sender, EventArgs e)
    {
         string connetionString = null;
         connetionString = "Data Source=ITWORKSDEV01;Initial Catalog=ITWorksDEV";
         using (SqlConnection cnn = new SqlConnection(connetionString))
         {
             cnn.Open();
    
