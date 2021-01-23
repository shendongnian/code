        using (var client = new basicsoap_ref.BasicSOAP_PortTypeClient())
        {
            try
            {
                string result = client.submitSoap("<root><test>Will</test></root>");
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            Console.Write("Done");
        }
