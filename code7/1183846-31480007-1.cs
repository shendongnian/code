    [HttpPost]
        public string WriteData(ShopItems item)
        {
            Product ob = new Product();
            bool result=ob.Write(item);
            if (result)
                return "true";
            else return "false";
        }
        
