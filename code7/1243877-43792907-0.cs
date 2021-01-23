        public async Task<IActionResult> CheckVAT()
        {
            var countryCode = "BE";
            var vatNumber = "123456789";
            try
            {
                checkVatPortType test = new checkVatPortTypeClient(checkVatPortTypeClient.EndpointConfiguration.checkVatPort, "http://ec.europa.eu/taxation_customs/vies/services/checkVatService");
                checkVatResponse response = await test.checkVatAsync(new checkVatRequest { countryCode = countryCode, vatNumber = vatNumber });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return Ok();
        }
