     ArrayList arraylist;
            List<string> adddistance = new List<string>();
            List<string> getfinallist = new List<string>();
      private void button1_Click(object sender, EventArgs e)
        {
            string s = "UNIT 01 CLIFF REACH GREENHITHE DA9 9SW,PINETOP BIRKLANDS LANE ST ALBANS AL1 1EE,HOLYWELL HILL ST ALBANS AL1 1BT,OLD RECTORY HOLYWELL HILL ST ALBANS AL1 1BY";
            button("DECATUR FARM ROAD CHICHESTER PO20 8JT", s);
        }
        public void button(string orign , string destination)
        {
           
            string[] words = destination.Split(',');
            foreach (string word in words)
            {
                getDistance(orign, word);
            }
            sorting();
           
        
        }
        public int getDistance(string origin, string destination)
        {
            System.Threading.Thread.Sleep(1000);
            int distance = 0;
          
            string url = "http://maps.googleapis.com/maps/api/directions/json?origin=" + origin +  "&destination=" + destination + "&sensor=false";
            string requesturl = url;
          
            string content = fileGetContents(requesturl);
            JObject o = JObject.Parse(content);
          
               
          string  strdistance = (string)o.SelectToken("routes[0].legs[0].distance.value") + " , " + destination + " , ";
                adddistance.Add(strdistance);
             
           
          
          
            return distance;
           
      
        }
        public void sorting()
        {  
           adddistance.Sort();
            string getfirststring = adddistance.FirstOrDefault().ToString() ;
            var vals = getfirststring.Split(',')[1];
            getfinallist.Add(getfirststring.Split(',')[1]);
           StringBuilder builder = new StringBuilder();
           adddistance.RemoveAt(0);
           
           foreach (string cat in adddistance) // Loop through all strings
           {
               builder.Append(cat); // Append string to StringBuilder
               
           }
      
           adddistance.Where((wors, index) => index % 2 == 0);
           string result = builder.ToString();
       
           string[] words = result.Split(',');
           string[] even = words.Where((str, ix) => ix % 2 == 1).ToArray();
       
           adddistance.Clear();
           foreach (string word in even)
            {                //string get = Regex.Match(word, @"^[" + numSet + @"]+$").ToString();
               
                if (word != " ")
                {
                    getDistance(vals, word);
                }               
              
            
            }
            sorting();
          
        
        }
        protected string fileGetContents(string fileName)
        {
            string sContents = string.Empty;
            string me = string.Empty;
            try
            {
                if (fileName.ToLower().IndexOf("http:") > -1)
                {
                    System.Net.WebClient wc = new System.Net.WebClient();
                    byte[] response = wc.DownloadData(fileName);
                    sContents = System.Text.Encoding.ASCII.GetString(response);
                }
                else
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
                    sContents = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch { sContents = "unable to connect to server "; }
            return sContents;
        }
