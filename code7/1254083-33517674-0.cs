    public IEnumerable<string> Products
            {
                get
                {
                    if(DateTime.Now.Date > Convert.ToDateTime("01-01-2016"))
                    {
                        //Return future product
                        return new List<string>();
                    }
                    else
                    {
                        // return current products
                        return new List<string>() { "testing" };
                    }
                }
                set
                {
                    if (DateTime.Now.Date > Convert.ToDateTime("01-01-2016"))
                    {
                        //ignore assign product
                        Products = new List<string>();
                    }
                    else
                    {
                        // add assign product
                        Products = value;
                    }
                }
            }
