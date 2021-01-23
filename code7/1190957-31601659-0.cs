    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Net.Http;
    using CTCT.Components.Contacts;
    using System.Net.Http.Headers;
    /// <summary>
    /// Constant Contact Helper Class for POST, PUT, and DELETE 
    /// </summary>
    public class ConstantContactHelper
    {
        private string _accessToken = ConfigurationManager.AppSettings["ccAccessToken"];
        private Dictionary<string, System.Net.Http.HttpMethod> requestDict = new Dictionary<string, System.Net.Http.HttpMethod> { 
            {"GET", HttpMethod.Get}, 
            {"POST", HttpMethod.Post}, 
            {"PUT", HttpMethod.Put}, 
            {"DELETE", HttpMethod.Delete} 
        };
        private System.Net.Http.HttpMethod requestMethod = null;
        private Dictionary<string, ConstantContactURI> uriDict = new Dictionary<string, ConstantContactURI> { 
            {"AddContact", new ConstantContactURI("contacts")},
            {"AddContactList", new ConstantContactURI("lists")},
            {"AddEmailCampaign", new ConstantContactURI("campaigns")},
        };
        private ConstantContactURI URI_Handler = new ConstantContactURI();
        private ContactRequestBody RequestBody = new ContactRequestBody();
        private const string messageType = "application/json";
        public string jsonRequest = null;
        public string responseXml = null;
        public string status_code = null;
    
	    public ConstantContactHelper()	{}
        public ConstantContactHelper(string methodKey, string uriKey, string firstName, string lastName, string emailAddress, string listId)
        {
            this.requestMethod = this.requestDict[methodKey];
            this.URI_Handler = this.uriDict[uriKey];
            this.RequestBody = new ContactRequestBody(firstName, lastName, emailAddress, listId);
        }
        // Return Response as a string
        public void TryRequest()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this._accessToken);
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(this.RequestBody.contact);
                    this.jsonRequest = json;
                    using (var request = new HttpRequestMessage(HttpMethod.Post, this.URI_Handler.fullURI))
                    {
                        request.Headers.Add("Accept", messageType);
                        request.Content = new StringContent(json);
                        request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse(messageType);
                        using (var response = client.SendAsync(request))
                        {
                            this.responseXml = response.Result.Content.ReadAsStreamAsync().ConfigureAwait(false).ToString();
                            this.status_code = response.Status.ToString();
                        }
                        request.Content.Dispose();                    
                    }
                }
            }
            catch(Exception exp)
            {
                // Handle Exception
                this.responseXml = "Unhandled exception: " + exp.ToString();
            }
        }
    }
    public class ConstantContactURI
    {
        private const string baseURI = "https://api.constantcontact.com/v2/";
        private const string queryPrefix = "?api_key=";
        private string _apiKey = ConfigurationManager.AppSettings["ccApiKey"];
        public string fullURI = null;
        public ConstantContactURI() {}
        public ConstantContactURI(string specificPath)
        {
            this.fullURI = baseURI + specificPath + queryPrefix + _apiKey;    
        }
    }
    public class ContactRequestBody
    {
        public Contact contact = new Contact();
        private List<EmailAddress> email_addresses = new List<EmailAddress>()
        {
            new EmailAddress{
                EmailAddr = "",
                Status = Status.Active,
                ConfirmStatus = ConfirmStatus.NoConfirmationRequired
            }
        };
        private List<ContactList> lists = new List<ContactList>()
        {
            new ContactList {Id = ""}
        };
        public ContactRequestBody() { }
        public ContactRequestBody(string firstName, string lastName, string emailAddress, string listId) 
        {
            this.contact.FirstName = firstName;
            this.contact.LastName = lastName;
        
            this.email_addresses[0].EmailAddr = emailAddress;
            this.contact.EmailAddresses = this.email_addresses;
        
            this.lists[0].Id = listId;
            this.contact.Lists = this.lists;
        }
    }
