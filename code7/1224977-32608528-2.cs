        using (var client = new basicsoap_ref.BasicSOAP_PortTypeClient())
        {
            try
            {
                int result = 0;
                string resultString = client.submitSoap("<root><test>Will</test></root>");
                int.TryParse(resultString, out result);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            Console.Write("Done");
        }
