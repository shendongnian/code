    public class handler
    {
        public string data_handler(string dt)
        {
             string handler_response= string.Empty;
             LibraryCaller.Master_Handler MH = new LibraryCaller.Master_Handler();
             string get_api_data = MH.Search(dt);
             JObject jObj = JObject.Parse(get_api_data);
             handler_response= jObj.ToString();
             HttpContext.Current.Session["HANDLER_RESPONSE"] = handler_response; // here currently using sesson
             return handler_response;
        }
    }
