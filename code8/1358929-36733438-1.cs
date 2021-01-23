            static int noOfTries = 0;
            protected void Page_Load(object sender, EventArgs e)
            {
                function();
            }
    
            private void function()
            {
              
                try
                {
                    
                    if (noOfTries == 10) goto XX;
                    noOfTries++;
                    int a = 0;
                    int b = 1 / a;
                   
                    
                }
                catch (Exception ew)
                {
                    Response.Write(ew.Message + "<br/>");
                    function();
    
                }
                XX:
                int c = 0;
            }
