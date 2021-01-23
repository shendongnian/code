     A.CallTo(() => _fctry.ConvertFromDto(null))
        .WithAnyArguments()
        .Returns(
            new TextUnit(
                new Dictionary<string,string>(){
                    { "Text", "This is my Text" }
                }
            )
        );
