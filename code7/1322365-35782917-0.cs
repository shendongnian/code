        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var content = output.GetChildContentAsync().Result.GetContent();
            var builder = new TagBuilder("a");
            builder.Attributes.Add("role", "button");
            builder.Attributes.Add("id", Name);
            builder.Attributes.Add("name", Name);
            output.Attributes.Add("data-controller", Controller);
            output.Attributes.Add("data-action", Action);
            
            builder.InnerHtml.Append(content);
            output.Content.SetContent(builder);
            return base.ProcessAsync(context, output);
        }
