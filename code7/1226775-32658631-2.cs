    catch (System.TimeoutException e)
    {
        var g = e.ToString();
        return false;
    }
    catch (System.Net.WebException e)
    {
        var g = e.ToString();
        return false;
    }
