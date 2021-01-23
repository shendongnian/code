    catch (WebException e)
    {
        using (var stream = e.Response.GetResponseStream())
        using (var reader = new StreamReader(stream))
        {
            Console.WriteLine(reader.ReadToEnd());
        }
    }
