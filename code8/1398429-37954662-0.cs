    Plugins.Add(new AutoQueryFeature {
        MaxLimit = 100,
        ResponseFilters = {
            ctx => { ctx.Response.Meta["COUNT(*)"] = "0"; }
        }
    });
