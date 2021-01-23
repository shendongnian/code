     using System;
     private static string MakeData(string name, string value)
     {
         return Uri.Escape(name) + "=" + Uri.Escape(value);
     }
     ...
    postData.Append("/reg_json?" + MakeData("GivenName", "findmeeasy"));
    postData.Append("&" + MakeData("FamilyName", "notebook"));
    /// etc.
