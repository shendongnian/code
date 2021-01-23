    subscription = images                
            .Do(source => source.Freeze())
            .Select(image => OcrService.Recognize(image))
            .SelectMany(image => {
                if (image.IsValid)
                    return Observable.Return(image);
                else
                    return UserFixTheImage(image).ToObservable().SelectMany(fix => fix ? Observable.Return(image) : Observable.Empty())
            })              
            .Subscribe(ocrResults => Upload(ocrResults));
