                string input = "on top on bottom on side Works this Magic door";
                List<string> array = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
      
                int onIndex = array.IndexOf("on");
                int sideIndex = array.IndexOf("side");
                int results = sideIndex - onIndex - 1;
