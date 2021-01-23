        // LOSER: Many WriteAsync calls with small strings
        private async Task TestWriteAsync(HttpContext context)
        {
            var r = context.Response;
            await r.WriteAsync("<div style='display:none'>");
            for (int i = 0; i < 10000; i++)
            {
                await r.WriteAsync(" " + i);
            }
            await r.WriteAsync("</div>");
        }
        // WINNER - String Builder
        private async Task TestStringBuilder(HttpContext context)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<div style='display:none'>");
            for (int i = 0; i < 10000; i++)
            {
                sb.Append(" " + i);
            }
            sb.AppendLine("</div>");
            await context.Response.WriteAsync(sb.ToString());
        }
