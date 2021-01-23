    RootObject a = JsonConvert.DeserializeObject<RootObject>(json);
    StringBuilder sb = new StringBuilder();
    foreach (Item item in a.items)
    {
        sb.Append(item.etag);
        sb.AppendLine(" ----- <br />");
    }
    Response.Write(sb.ToString());
