    catch (WebException ex)
    {
        using (var reader = new StreamReader(ex.Response.GetResponseStream()))
        {
            string responseText = reader.ReadToEnd();
        }
    }
