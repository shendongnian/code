            string servResp = await response.Content.ReadAsStringAsync();
            try
            {
                geoCodeResponse = servResp.DeserializeXml<GoogleAPI.GeocodeResponse>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
