    public string RemoveCountryCode()
    {
      Uri originalUri = new Uri("http://example.com/UK/Deal.aspx?id=322");
      string hostAndPort = originalUri.GetLeftPart(UriPartial.Authority);
      // v1: if country code is always there, always has same position and always
      // has format 'XX' this is definitely the easiest and fastest
      string trimmedPathAndQuery = originalUri.PathAndQuery.Substring("/XX/".Length);
      // v2: if country code is always there, always has same position but might
      // not have a fixed format (e.g. XXX)
      trimmedPathAndQuery = string.Join("/", originalUri.PathAndQuery.Split('/').Skip(2));
      // in both cases you need to join it with the authority again
      return string.Format("{0}/{1}", hostAndPort, trimmedPathAndQuery);
    }
