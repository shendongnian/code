    public void Randommesg()
    {
        Random r = new Random();
        int k1 = 10;
        for (int i = 0; i <= k1; i++)
        {
    
            List<double> rscore = new List<double>();
            List<string> messagetype = new List<string>();
            Message msg = new Message(messagetype, rscore);
            messagetype.Clear();
            rscore.Clear();
            int mnum = r.Next(6);
            while (messagetype.Count <= mnum)
            {
                string[] arr = { "sports", "reebok", "nike", "adidas", "cookware", "home decor", "tools", "toys", "clothes", "appliances", "electronics", "phones", "computers" };
                int i1 = r.Next(13);
                String mesgtype = arr[i1];
                if (messagetype.Contains(mesgtype))
                {
                    continue;
                }
                else
                {
                    messagetype.Add(mesgtype);
                }
            }
            while (rscore.Count <= messagetype.Count)
            {
                Double i2 = r.NextDouble();
                String score1 = i2.ToString("0.#");
                Double score2 = double.Parse(score1);
                rscore.Add(score2);
            }
            msg._messageCategories = messagetype;
            msg._relevanceScore = rscore;
            msg.id = i;
            message.Add(msg);
        }
    }
