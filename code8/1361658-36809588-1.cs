        //Add the radio buttons
        for(var x =0; x<5; x++)
        {
            var input = new TagBuilder("input");
            input.MergeAttribute("type", "radio");
            input.MergeAttribute("name", ModelField);
            input.MergeAttribute("value", x.ToString());
            output.Content.Append(input);
        }
