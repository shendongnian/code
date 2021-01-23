    protected string CheckIfApproved(object isApproved) 
        {
            string result;
            if (bool.Parse(isApproved))
            {
                result = "Satışa Dönmüştür";
            }
            else
            {
                result = "Satışa Dönmemiştir";
            }
                return result;
        }
