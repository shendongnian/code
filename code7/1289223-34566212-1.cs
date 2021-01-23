    public List<string> Post()//[FromBody]string custName)
        {
            HttpContent requestContent = Request.Content;
            string custName = requestContent.ReadAsStringAsync().Result;
            try
            {
                names.Add(custName);
                return names;
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string> {ex.Message};
                return errors;
            }
        }
