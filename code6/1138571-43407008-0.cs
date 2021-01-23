    // Raw URI including query string with multiple parameters
    var rawurl = "https://bencull.com/some/path?key1=val1&key2=val2&key2=valdouble&key3=";
    // Parse URI, and grab everything except the query string.
    var uri = new Uri(rawurl);
    var baseUri = uri.GetComponents(UriComponents.Scheme | UriComponents.Host | UriComponents.Port | UriComponents.Path, UriFormat.UriEscaped);
    // Grab just the query string part
    var query = QueryHelpers.ParseQuery(uri.Query);
    // Convert the StringValues into a list of KeyValue Pairs to make it easier to manipulate
    var items = query.SelectMany(x => x.Value, (col, value) => new KeyValuePair<string, string>(col.Key, value)).ToList();
    // At this point you can remove items if you want
    items.RemoveAll(x => x.Key == "key3"); // Remove all values for key
    items.RemoveAll(x => x.Key == "key2" && x.Value == "val2"); // Remove specific value for key
    // Use the QueryBuilder to add in new items in a safe way (handles multiples and empty values)
    var qb = new QueryBuilder(items);
    qb.Add("nonce", "testingnonce");
    qb.Add("payerId", "pyr_");
    // Reconstruct the original URL with new query string
    var fullUri = baseUri + qb.ToQueryString();
