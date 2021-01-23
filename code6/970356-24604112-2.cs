    [System.Web.Services.WebMethod]
        public static string getDistrict()
        {
            int pincode = Convert.ToInt32(HttpContext.Current.Request.QueryString["pincode"].ToString().Trim());
            string district = "";
            //code to fetch district
            return district;
        }
