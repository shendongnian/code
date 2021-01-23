     string[] strs = File.ReadAllLines (response);
     List<Details>list new List<Details>();
     foreach(string str in str)
     {
         list.Add(JsonConvert.DeserializeObject<Details>(str));
     }
