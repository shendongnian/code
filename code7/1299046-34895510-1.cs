    subscription = images                
            .Do(source => source.Freeze())
            .Select(image => OcrService.Recognize(image))
            .SelectMany(ocrResults=> {
                if (image.IsValid)
                    return Observable.Return(ocrResults);
                else
                    return UserFixesTheOcrResults(ocrResults).ToObservable().SelectMany(fix => fix ? Observable.Return(ocrResults) : Observable.Empty())
            })              
            .Subscribe(ocrResults => Upload(ocrResults));
