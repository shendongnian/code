    public async virtual Task Delete()
    {
            HttpResponse r = new HttpResponse();
            r = await CallAPI(_Objectname.ToString(), _Id.ToString(), HttpMethod.DELETE).ConfigureAwait(false);                         
    }
