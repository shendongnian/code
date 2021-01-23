        catch (WebException wex)
        {
            if (wex.Response != null)
            {
                lcResult = "ERROR (web exception, response generated): " + Environment.NewLine + new StreamReader(wex.Response.GetResponseStream()).ReadToEnd();
            }
            else
            {
                lcResult = "ERROR (web exception, NO RESPONSE): " + wex.Message + wex.StackTrace;
            }
        }
