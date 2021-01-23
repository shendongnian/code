    var encrypted = encryptionDal.EncryptDataWithSalt(encryptionItems, salt);
    var sb = new StringBuilder();
    foreach (var kvp in encrypted)
        sb.AppendFormat("&{0}={1}", WebUtility.UrlEncode(kvp.Key), WebUtility.UrlEncode(kvp.Value));
    var queryString = sb.ToString(1, sb.Length-1); // assuming non-empty
