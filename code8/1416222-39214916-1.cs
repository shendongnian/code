    public class Utility
    {
        public static void UpdateReadonlyQueryString(NameValueCollection collectionToUpdate, string paramName, string paramValue, HttpRequest Request)
        {
            collectionToUpdate = (NameValueCollection)Request.GetType().GetField("_queryString", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(Request);
            PropertyInfo readOnlyInfo = collectionToUpdate.GetType().GetProperty("IsReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            readOnlyInfo.SetValue(collectionToUpdate, false, null);
            collectionToUpdate[paramName] = paramValue;
            readOnlyInfo.SetValue(collectionToUpdate, true, null);
        }
        public static void AddToReadonlyQueryString(NameValueCollection collectionToUpdate, string paramName, string paramValue, HttpRequest Request)
        {
            collectionToUpdate = Request.QueryString;
            collectionToUpdate = (NameValueCollection)Request.GetType().GetField("_queryString", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(Request);
            PropertyInfo readOnlyInfo = collectionToUpdate.GetType().GetProperty("IsReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            readOnlyInfo.SetValue(collectionToUpdate, false, null);
            collectionToUpdate.Add( paramName, paramValue);
            readOnlyInfo.SetValue(collectionToUpdate, true, null);
        }
    }
