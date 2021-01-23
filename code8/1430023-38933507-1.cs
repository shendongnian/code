    public async bool Authorization(string korisnik, string zaporka){
        ...
        try {
            //will always throw an exception if not successful
            response.EnsureSuccessStatusCode();
            var response = await client.PostAsync("http://www.etfos.unios.hr/~tsapina/autorizacija.php", content);
    
            if (httpResponse.Content != null) {
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
    
                var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);
    
                Console.WriteLine(dict["post_var_key"]);
            }
        }
        catch (Exception ex) {
            Console.WriteLine("Error occured: " + ex.Message);
        }
    }
