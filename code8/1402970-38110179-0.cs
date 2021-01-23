        IResponseFilter IRequestHandler.GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response) {
            var url = new Uri(request.Url);
           
            if (request.Url.Equals(scriptToUpdate, StringComparison.OrdinalIgnoreCase)) {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                dictionary.Add(search1, replace1);
                dictionary.Add(search2, replace2);
                return new FindReplaceResponseFilter(dictionary);
            }
            return null;
        }
