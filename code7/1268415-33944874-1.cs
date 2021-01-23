        private async Task TestWriteAsync(HttpContext context)
        {
            var r = context.Response;
            var id = "id";
            var size = "12";
            var text = "text";
            await r.WriteAsync("<div style='display:none'>");
            for (int i = 0; i < 10000; i++)
            {
                await r.WriteAsync("<li id='");
                await r.WriteAsync(id);
                await r.WriteAsync("' style='font-size:");
                await r.WriteAsync(size);
                await r.WriteAsync("'>");
                await r.WriteAsync(text);
                await r.WriteAsync("</li>");
            }
            await r.WriteAsync("</div>");
        }
        private async Task TestWriteAsyncFormat(HttpContext context)
        {
            var r = context.Response;
            var id = "id";
            var size = "12";
            var text = "text";
            var template = "<li id='{0}' style='font-size:{1}'>{2}</li>";
            await r.WriteAsync("<div style='display:none'>");
            for (int i = 0; i < 10000; i++)
            {
                await r.WriteAsync(string.Format(template, id, size, text));
            }
            await r.WriteAsync("</div>");
        }
        private async Task TestStringBuilder(HttpContext context)
        {
            var sb = new StringBuilder();
            var id = "id";
            var size = "12";
            var text = "text";
            sb.Append("<div style='display:none'>");
            for (int i = 0; i < 10000; i++)
            {
                sb.Append("<li id='");
                sb.Append(id);
                sb.Append("' style='font-size:");
                sb.Append(size);
                sb.Append("'>");
                sb.Append(text);
                sb.Append("</li>");
            }
            sb.Append("</div>");
            await context.Response.WriteAsync(sb.ToString());
        }
        private async Task TestStringBuilderFormat(HttpContext context)
        {
            var sb = new StringBuilder();
            var id = "id";
            var size = "12";
            var text = "text";
            var template = "<li id='{0}' style='font-size:{1}'>{2}</li>";
            sb.Append("<div style='display:none'>");
            for (int i = 0; i < 10000; i++)
            {
                sb.AppendFormat(template, id, size, text);
            }
            sb.Append("</div>");
            await context.Response.WriteAsync(sb.ToString());
        }
