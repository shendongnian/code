    catch (WebException we)
     {
        StreamReader resultReader = new StreamReader(we.Response.GetResponseStream());
        string result = resultReader.ReadToEnd();
        resultReader.Close();
        return result;
     }
     catch (Exception e)
     {
        return e.Message;
     }
