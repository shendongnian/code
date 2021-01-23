    catch (TimeoutException e)
    {
         var g = e.ToString();
         return false;
    }
    catch (WebException e)
    {
         var g = e.ToString();
         return false;
    }
