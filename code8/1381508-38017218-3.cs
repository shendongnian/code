    /// <summary>
    /// Manipulate the URL before the WebAPI request has been processed.
    /// AllowedSelectProperties may contain a CSV list of allowed field names to $select
    /// </summary>
    /// <remarks>If AllowedSelectProperties does not have a value, do not modify the request</remarks>
    /// <param name="actionContext">Current Action context, access the Route defined parameters and the raw http request</param>
    public override void OnActionExecuting(HttpActionContext actionContext)
    {
        // Only modify the request if AllowedSelectProperties has been specified
        if (!String.IsNullOrWhiteSpace(this.AllowedSelectProperties))
        {
            // parse the url parameters so we can process them
            var tokens = actionContext.Request.RequestUri.ParseQueryString();
            // CS: Special Case - if $apply is requested, DO NOT process defaults, $apply must be fully declared in terms of outputs and filters by the caller
            // $apply is outside of the scope of this question :) so if it exists, skip this logic.
            if (String.IsNullOrEmpty(tokens["$apply"]))
            {
                // check the keys, do not evaluate if the value is empty, empty is allowed
                // if $expand is specified, and by convention and should not return any fields from the root element
                if (!tokens.AllKeys.Contains("$select"))
                    tokens["$select"] = this.AllowedSelectProperties;
                else
                {
                    // We need to parse and modify the $select token
                    var select = tokens["$select"];
                    IEnumerable<string> selectFields = select.Split(',').Select(x => x.Trim());
                    IEnumerable<string> allowedFields = this.AllowedSelectProperties.Split(',').Select(x => x.Trim());
                    // Intersect allows us to ujse our allowedFields as a MASK against the requested fields
                    // NOTE: THIS IS PASSIVE, you could throw an exception if you want to prevent execution when an invalid field is requested.
                    selectFields = selectFields.Intersect(allowedFields, StringComparer.OrdinalIgnoreCase);
                    tokens["$select"] = string.Join(",", selectFields);
                }
                // Rebuild our modified URI
                System.Text.StringBuilder result = new System.Text.StringBuilder();
                result.Append(actionContext.Request.RequestUri.AbsoluteUri.Split('?').First());
                if (tokens.Count > 0)
                {
                    result.Append("?");
                    result.Append(String.Join("&", 
                        tokens.AllKeys.Select(key => 
                            String.Format("{0}={1}", key, Uri.EscapeDataString(tokens[key]))
                            )
                        )
                    );
                }
                // Apply the modified Uri to the action context
                actionContext.Request.RequestUri = new Uri(result.ToString());
            }
        }
        // Allow the base logic to complete
        base.OnActionExecuting(actionContext);
    }
