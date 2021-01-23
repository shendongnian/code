    public List<Product> fillProduct()
        {
            List<Product> AllProducts = new List<Product>();
            //fill 
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (product p in fillProduct())
            {
                Console.WriteLine(p);
            }
        }
