    private void read_file_list()
        {
            string line;
            try
            {
                using (StreamReader sr = new StreamReader("list.txt"))
                {
                    line = sr.ReadToEnd();
                }
                JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                postlist = JsonConvert.DeserializeObject<List<Post>>(line, jsonSerializerSettings);
            }
            catch 
            {
               // catch your exception if you want
            }
        }
