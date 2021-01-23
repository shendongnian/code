    private void btnSearch_Click(object sender, EventArgs e)
    {
       var date1 = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
       var date2 = dateTimePicker2.Value.Date.ToString("yyyy-MM-dd");
    
       HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://***.**.***.***/time.php");
       request.Method = "POST";
       request.ContentType = "application/x-www-form-urlencoded";
       byte[] byteArray = Encoding.UTF8.GetBytes("fromdate= " + date1 + " & todate=" + date2);
       request.ContentLength = byteArray.Length;
       Stream stream = request.GetRequestStream();
       stream.Write(byteArray, 0, byteArray.Length);
       HttpWebResponse response = (HttpWebResponse)request.GetResponse();
       StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
       String json = reader.ReadToEnd();
       List<Users> user = JsonConvert.DeserializeObject<List<Users>>(json);
       dataGridView1.DataSource = user;
