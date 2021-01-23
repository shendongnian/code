    subscription = images                
            .Do(source => source.Freeze())
            .Select(image => OcrService.Recognize(image))
            .Select(ocrResults=> {
                if (ocrResults.IsValid)
                    return Observable.Return(ocrResults);
                else
                    return UserFixesTheOcrResults(ocrResults).ToObservable().Select(_ => ocrResults)
            })
            .Concat()             
            .Subscribe(ocrResults => Upload(ocrResults));
