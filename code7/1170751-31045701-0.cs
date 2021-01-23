    public NpuHeader npuHeaderOut = new NpuHeader();
    ...
    [SoapHeader("npuHeaderOut", Direction = SoapHeaderDirection.Out)]
    public string obterSiteDocumentacaoUrl(NpuHeader npuHeader, string pedido)
    {
        string url = null;
        if (validaNpuHeader(ref npuHeader))
        {
            try
            {
                url = dataAccess.obterSiteDocumentacaoUrl(pedido);
                npuHeader.ResponseSuccess.Add(
                        new GeneralResponseSuccess(WebServiceBusinessResult.SUCESSO, "Sucesso")
                        );
            }
            catch (Exception ex)
            {
                npuHeader.ResponseSuccess.Add(
                    new GeneralResponseSuccess(WebServiceBusinessResult.OUTROS, ex.Message)
                );
            }
        }
        npuHeaderOut.ResponseSuccess = npuHeader.ResponseSuccess;
        npuHeaderOut.correlationNPU = npuHeader.npu;
        npuHeaderOut.npu = CreateNPU("", "");
        npuHeaderOut.systemCode = SistemaOrigem;
        npuHeaderOut.creationTime = DateTime.Now;
        npuHeaderOut.operationDate = DateTime.Now;
        return url;
    }
