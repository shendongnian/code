        // your request must include these, and a given name,
        // everything else is optional
        private const string odata = "@odata.type";
        private const string type = "#Microsoft.Exchange.Services.OData.Model.Contact";
        public static async Task CreateContact(ContactObject officeContact, string userEmail, string userPassword)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, new Uri("https://outlook.office365.com/ews/odata/Me/Contacts"));
            // Add the Authorization header with the basic login credentials.
            var auth = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(userEmail + ":" + userPassword));
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization", auth);
            var createResponse = new JObject();
            createResponse[odata] = type; // this needs to be here for this to work
            if (!String.IsNullOrEmpty(officeContact.officeDisplayName)) createResponse["DisplayName"] = officeContact.officeDisplayName;
            if (!String.IsNullOrEmpty(officeContact.officeGivenName)) createResponse["GivenName"] = officeContact.officeGivenName;
            if (!String.IsNullOrEmpty(officeContact.officeMiddleName)) createResponse["MiddleName"] = officeContact.officeMiddleName;
            if (!String.IsNullOrEmpty(officeContact.officeNickName)) createResponse["NickName"] = officeContact.officeNickName;
            if (!String.IsNullOrEmpty(officeContact.officeSurname)) createResponse["Surname"] = officeContact.officeSurname;
            if (!String.IsNullOrEmpty(officeContact.officeEmailAddress1)) createResponse["EmailAddress1"] = officeContact.officeEmailAddress1;
            if (!String.IsNullOrEmpty(officeContact.officeEmailAddress2)) createResponse["EmailAddress2"] = officeContact.officeEmailAddress2;
            if (!String.IsNullOrEmpty(officeContact.officeEmailAddress3)) createResponse["EmailAddress3"] = officeContact.officeEmailAddress3;
            if (!String.IsNullOrEmpty(officeContact.officeHomePhone1)) createResponse["HomePhone1"] = officeContact.officeHomePhone1;
            if (!String.IsNullOrEmpty(officeContact.officeHomePhone2)) createResponse["HomePhone2"] = officeContact.officeHomePhone2;
            if (!String.IsNullOrEmpty(officeContact.officeBusinessPhone1)) createResponse["BusinessPhone1"] = officeContact.officeBusinessPhone1;
            if (!String.IsNullOrEmpty(officeContact.officeBusinessPhone2)) createResponse["BusinessPhone2"] = officeContact.officeBusinessPhone2;
            if (!String.IsNullOrEmpty(officeContact.officeMobilePhone1)) createResponse["MobilePhone1"] = officeContact.officeMobilePhone1;
            if (!String.IsNullOrEmpty(officeContact.officeOtherPhone)) createResponse["OtherPhone"] = officeContact.officeOtherPhone;
            if (!String.IsNullOrEmpty(officeContact.officeId)) createResponse["Id"] = officeContact.officeId;
            if (!String.IsNullOrEmpty(officeContact.officeCompanyName)) createResponse["CompanyName"] = officeContact.officeCompanyName;
            request.Content = new StringContent(JsonConvert.SerializeObject(createResponse));
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.SendAsync(request);
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("BAD REQUEST");
            }
        }
