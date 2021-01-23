    httpConfig.EnableSwagger(c => {
                    if (GetXmlCommentsPath() != null) {
                        c.IncludeXmlComments(GetXmlCommentsPath());
                    }
    ...
    ...
    );
    protected static string GetXmlCommentsPath() {
        var path = HostingEnvironment.MapPath("path to your xml doc file");
        return path;
    }
