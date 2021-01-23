    public async Task<ApiResponse<ProductLookupDto>> GetProductsByValueOfTheDay()
    {
        string url = "http://domain.com?param=10120&isBasic=true";
        var result = await url.GetJsonAsync<ProductLookupDto>();
        return new ApiResponse<ProductLookupDto>()
        {
            Data = result,
            Message = "success"
        };
    }
