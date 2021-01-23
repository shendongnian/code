    InvokeMethodResult result = await MyAllJoynMethod.InvokeAsync(new List<object> { "parameter", 2 });
    if (result.Status.IsSuccess)
    {
        var resultList = result.Values as IList<object>;
        foreach (var resultListItem in resultList)
        {
            var pairs = resultListItem as IList<KeyValuePair<object, object>>;
            foreach (var pair in pairs)
            {
                var key = pair.Key as string; //<- type string taken from MyAllJoynMethod definition
                var variant = pair.Value as AllJoynMessageArgVariant;//<- type AllJoynMessageArgVariant taken from MyAllJoynMethod definition (variant)
                if (variant.TypeDefinition.Type == TypeId.Uint8Array)
                {
                    var array8 = j as IList<object>;
                    foreach (byte b in array8)
                    {
                        // do something with b
                    }
                }
            }
        }
    }
