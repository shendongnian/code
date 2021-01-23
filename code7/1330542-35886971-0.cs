    public async Task WaitForElementToLoad(String key)
        {
            element = wb.Document.GetElementById(key);
            CancellationToken ct = new CancellationTokenSource(10000).Token;
            
            var doc = wb.Document;
            while (true)
            {
                await Task.Delay(20, ct);
                element = wb.Document.GetElementById(key);
                if (element != null)
                    if (element.InnerHtml != null)
                        break;
                doc = wb.Document;
            }
            ct.ThrowIfCancellationRequested();
        }
