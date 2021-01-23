    public class YourModel
    {
        public YourModel(string xy, string price)
        {
            float forTest = 0;
            XYNUMBER = xy;
    
            string addForParse = string.Format("{0}.{1}", price.Substring(0, price.Length - 2), price.Substring(price.Length - 2, 2));
    
            if (float.TryParse(addForParse, out forTest)) 
            {
                Price = forTest;
            }
        }
        public string XYNUMBER { get; set; }
        public float Price { get; set; }
    }
