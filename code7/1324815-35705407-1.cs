        public class Contact
        {
            public string ID{ get; set; } //change to the correct type
            public string Name{ get; set; }
        }
        //...
        static public async Task<List<Contact>> getOurMainInfo() //Make it J0bject immediately? Or somehow transform it inside this function?
        {
            var httpClientRequest = new HttpClient ();
            var result = await httpClientRequest.GetAsync ("http://localhost/getMyPhp.php");
            var resultString = await result.Content.ReadAsStringAsync ();
            var jsonResult = JsonConvert.DeserializeObject<List<Contact>>(resultString);
            return jsonResult;
    }
