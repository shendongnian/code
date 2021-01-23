     public static int getCountMyJson(JObject json)
        {
            int i = 0;
          while(json.GetValue(i+"") != null)
            { i++; }
            return i;
        }
