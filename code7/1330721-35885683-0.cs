    public void MyMethod()
            {
                if (CheckInternetConnection() == false)
                {
                    Response.Redirect("custompage.aspx");
                }
                else
                {
                    //your application method
                }
            }
    
            public bool CheckInternetConnection()
            {
                try
                {
                    using (var obj = new WebClient())
                    {
                        using (var stream = obj.OpenRead("http://www.google.co.in"))
                        {
                            return true;
                        }
                    }
                }
                catch
                {
                    return false;
                }
            }
