      private void loadtoage(int fromage)
    {
        //to age
        for (int i = fromage; i <= 50; i++)
        {
            string text = i.ToString();// convert i to string just once. you are converting it again in next line. boxing and unboxing is expensive when it comes to performance. 
            ListItem li = new ListItem(text, i.ToString());//Rather than doing i.ToString() again, you can directly pass text. Its all same. 
            ddlToAge.Items.Add(li);
        }
    }
