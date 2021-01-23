     public int DoHttpOperation(HttpClient client, parameters param)
            {
                url = "url which you want to hit";
                client.DefaultRequestHeaders.Add("headername", "headervalue");
                var response = //operation which you want to perfrom GET/PUT/POST/DELETE
                return ((int)response.StatusCode);  //Here you will o/p 
            }
