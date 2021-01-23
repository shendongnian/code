        List<string> priceList = new List<string>();
        public virtual void tickPrice(int tickerId, int field, double price, int canAutoExecute)
        {
            Console.WriteLine("Tick Price. Ticker Id:" + tickerId + ", Field:" + field + ", Price:" + price + ", CanAutoExecute: " + canAutoExecute + "\n");
          
            // here you add your prices to list
            priceList.Add(price);
            string str = Convert.ToString(price);
            System.IO.File.WriteAllText(@"C:\Users\XYZ\Documents\price.txt", str);
        }
