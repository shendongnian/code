            docTypeList.Add(Guid.NewGuid().ToString(), "C");
            docTypeList.Add(Guid.NewGuid().ToString(), "F17");
            docTypeList.Add(Guid.NewGuid().ToString(), "F1");
            docTypeList.Add(Guid.NewGuid().ToString(), "B");
            docTypeList.Add(Guid.NewGuid().ToString(), "F");
            docTypeList.Add(Guid.NewGuid().ToString(), "F2");
            docTypeList.Add(Guid.NewGuid().ToString(), "Z");
            docTypeList.Add(Guid.NewGuid().ToString(), "F20");
            docTypeList.Add(Guid.NewGuid().ToString(), "X");
            docTypeList.Add(Guid.NewGuid().ToString(), "A");
            docTypeList.Add(Guid.NewGuid().ToString(), "Y");
            var ordered = docTypeList.OrderBy(x => new string(x.Value.TakeWhile(c => !char.IsDigit(c)).ToArray()))
                .ThenBy(x => int.Parse(
                    x.Value.Any(char.IsDigit) ? new string(x.Value.SkipWhile(c => !char.IsDigit(c)).TakeWhile(char.IsDigit).ToArray()) : "0"
                    ));
